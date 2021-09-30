using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Database
{
    public class ApplicationDbContext: IApplicationDbContext
    {
        private readonly IConnectionMultiplexer _redis;
        public IDatabase Database { 
            get {
                return _redis.GetDatabase();
            } 
        }

        public ApplicationDbContext(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

    }

    public static class GetDatabaseExtensionMethods
    {

        public static List<string> Scan(this IDatabase redis, string pattern)
        {
            List<string> keys = new List<string>();

            int cursor = 0;
            RedisResult result;
            do
            {
                result = redis.Execute("scan", new object[] { cursor, "match", pattern });
                RedisResult[] innerResult = (RedisResult[])result;
                cursor = int.Parse((string)innerResult[0]);
                keys.AddRange(((string[])innerResult[1]).ToList());
            }
            while (cursor != 0);

            return keys;
        }


        public static HashEntry[] ToHashEntries(this object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            return properties.Select(property => new HashEntry(property.Name, property.GetValue(obj).ToString())).ToArray();
        }

        public static T ConvertFromRedis<T>(this HashEntry[] hashEntries)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var obj = Activator.CreateInstance(typeof(T));
            foreach (var property in properties)
            {
                HashEntry entry = hashEntries.FirstOrDefault(g => g.Name.ToString().Equals(property.Name));
                if (entry.Equals(new HashEntry())) continue;
                if (!property.PropertyType.Equals(typeof(Guid)))
                {
                    property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                }
                else
                {
                    property.SetValue(obj, Convert.ChangeType(Guid.Parse(entry.Value.ToString()), property.PropertyType));
                }
                
            }
            return (T)obj;
        }
    }
}
