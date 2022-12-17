using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Server.Database
{
    public class DatabaseCommand : DatabaseConnection, IDisposable
    {
        private readonly MySqlCommand _MySqlCommand;

        public DatabaseCommand()
        {
            this._MySqlCommand = new MySqlCommand();
            this._MySqlCommand.Connection = base._mySqlConnection;
        }

        public void SetCommand(string command)
        {
            this._MySqlCommand.CommandText = command;
        }

        public void AddParameter(string name, object value)
        {
            this._MySqlCommand.Parameters.AddWithValue(name, value);
        }

        public void ExecuteQuery()
        {
            base.OpenConnection();
            int rowsAffected = this._MySqlCommand.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteDataReader()
        {
            base.OpenConnection();
            return this._MySqlCommand.ExecuteReader();
        }

        public void Dispose()
        {
            this._MySqlCommand.Dispose();
            base.CloseConnection();
            base._mySqlConnection.Dispose();
        }
    }
}
