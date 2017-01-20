using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApp
{
    public class Config
    {
        private static string Server = "127.0.0.1";
        private static string Database = "fifo db";
        private static string User = "root";
        private static string Password = "1234";

        /// <summary>
        /// Creates the correct string to connect to the database
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Server, Database, User, Password);
        }
    }
}
