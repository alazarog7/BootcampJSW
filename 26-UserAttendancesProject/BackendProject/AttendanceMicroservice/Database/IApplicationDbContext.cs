using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceMicroservice.Database
{
    public interface IApplicationDbContext
    {
        public IDatabase Database { get; }
    }
}
