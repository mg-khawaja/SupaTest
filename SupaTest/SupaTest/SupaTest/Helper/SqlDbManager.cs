using SupaTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SupaTest.Helper
{
    public static class SqlDbManager
    {
        // set here your sql server's ip address
        static string server = "192.168.9.27";
        static string db = "SupaDb";
        // set here username
        static string user = "supa";
        // set here password
        static string password = "123456";

        public static SqlConnection Connection;
        //open sql connection
        public static async Task Initialise()
        {
            string sqlconn = $"Data Source={server};Initial Catalog={db};User ID={user};Password={password}";
            Connection = new SqlConnection(sqlconn);
            await Connection.OpenAsync();
        }
        // create network code in sql server
        public static async Task<bool> CreateNetworkCode(NetworkCode networkCode)
        {
            string query = $"insert into [Code]([code],[network]) values('{networkCode.Code}','{networkCode.Network}')";
            SqlCommand command = new SqlCommand(query, Connection);

            command.Connection = Connection;
            command.CommandText = query;
            var result = await command.ExecuteReaderAsync();
            //check if account exists
            if (result.RecordsAffected > 0)
            {
                result.Close();
                return true;
            }
            result.Close();
            return false;
        }
        // verify network code from sql server
        public static async Task<bool> VerifyNetworkCode(NetworkCode networkCode)
        {
            string query = $"select * from [Code] where code = '{networkCode.Code}' and network = '{networkCode.Network}'";
            SqlCommand command = new SqlCommand(query, Connection);

            command.Connection = Connection;
            command.CommandText = query;
            var result = await command.ExecuteReaderAsync();
            //check if account exists
            var exists = result.HasRows;
            result.Close();
            return exists;
        }
        // get random user from sql server
        public static async Task<User> GetRandomUser()
        {
            string query = "SELECT top 1 * FROM [User]  ORDER BY NEWID()";
            SqlCommand command = new SqlCommand(query, Connection);

            command.Connection = Connection;
            command.CommandText = query;
            var result = await command.ExecuteReaderAsync();
            //check if account exists
            var exists = result.HasRows;
            while (result.Read())
            {
                var user = new User()
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                };
                result.Close();
                return user;
            }
            result.Close();
            return null;
        }
    }
}
