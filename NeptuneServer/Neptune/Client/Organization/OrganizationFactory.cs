using NeptuneServer.Neptune.Client.Users;
using NeptuneServer.Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client.Organization
{
    public class OrganizationFactory
    {
        public static bool TryGetOrganization(string sid, string authToken, out Organization organization)
        {
            organization = null;

            if (string.IsNullOrEmpty(sid) || string.IsNullOrEmpty(authToken))
            {
                return false;
            }

            try
            {
                using (var command = new DatabaseCommand())
                {
                    command.SetCommand("SELECT * FROM organizations WHERE sid = @sid && auth_token = @auth LIMIT 1");
                    command.AddParameter("sid", sid);
                    command.AddParameter("auth", authToken);

                    using (var reader = command.ExecuteDataReader())
                    {
                        if (reader == null)
                        {
                            return false;
                        }

                        while (reader.Read())
                        {
                            organization = new()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                Name = reader["name"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Log to file
            }

            return organization != null;
        }
    }
}
