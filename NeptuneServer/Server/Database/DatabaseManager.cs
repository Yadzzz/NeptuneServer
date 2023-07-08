using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NeptuneServer.Server.Database
{
    public class DatabaseManager
    {
        public DatabaseManager()
        {
            Console.WriteLine("DatabaseManager Initialized ->");
        }

        public DatabaseCommand CreateDatabaseCommand()
        {
            return new DatabaseCommand();
        }
    }
}
