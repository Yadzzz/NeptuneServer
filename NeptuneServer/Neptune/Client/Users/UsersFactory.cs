using NeptuneServer.Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client.Users
{
    public static class UsersFactory
    {
        public static bool TryGetUser(string authToken, out User user)
        {
            user = null;

            if (string.IsNullOrEmpty(authToken))
            {
                return false;
            }

            using (var command = new DatabaseCommand())
            {
                command.SetCommand("SELECT * FROM users WHERE auth_token = @auth LIMIT 1");
                command.AddParameter("auth", authToken);

                using (var reader = command.ExecuteDataReader())
                {
                    if (reader == null)
                    {
                        return false;
                    }

                    while (reader.Read())
                    {
                        user = new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString(),
                            EmailAdress = reader["email_adress"].ToString(),
                            AuthToken = authToken
                        };
                    }
                }
            }

            return user != null;
        }
    }
}
