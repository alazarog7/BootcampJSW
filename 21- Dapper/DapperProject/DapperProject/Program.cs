using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DapperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=127.0.0.1,1433;Database=Catalog;User=sa;Password=123";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    //string sql = "INSERT INTO [Catalog].[Catalog].[Products](Name, Description, Price) VALUES ('gARRAFA','BUENO',12.2)";

            //    string sql = "UPDATE [Catalog].[Catalog].[Products] SET NAME ='Garrafon' WHERE ProductId=103";

            //    var rows = connection.Execute(sql);

            //    Console.WriteLine(rows);
            //}

            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "select UserId, Name, a.PhoneId, Number, FixedNumber from TB_User a inner join tb_Phone b on a.PhoneId = b.PhoneId";
                var invoices = connection.Query<User, Phone, User>(
                   sql,
                   (user, phone) =>
                   {
                       user.Phone = phone;
                       return user;
                   },
                   splitOn: "PhoneId").FirstOrDefault();

                Console.WriteLine(invoices);
            }
        }
    }
}
