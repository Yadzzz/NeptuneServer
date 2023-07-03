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
            try
            {
                using (MySqlConnection connection = new MySqlConnection(NeptuneConfiguration.ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
            }
            catch (MySqlException e)
            {
                throw e;
            }

            Console.WriteLine("DatabaseManager Initialized ->");
        }

        public DatabaseCommand CreateDatabaseCommand()
        {
            return new DatabaseCommand();
        }
    }
}
