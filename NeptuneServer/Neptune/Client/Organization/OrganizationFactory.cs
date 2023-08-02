using NeptuneServer.Neptune.Client.Users;
using NeptuneServer.Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static bool IsAllowedUser(int userId, int organizationId)
        {
            try
            {
                using (var command = new DatabaseCommand())
                {
                    command.SetCommand("SELECT * FROM organizations_users WHERE user_id = @userId && organization_id = @orgId && active = @active LIMIT 1");
                    command.AddParameter("userId", userId);
                    command.AddParameter("orgId", organizationId);
                    command.AddParameter("active", 1);

                    using (var reader = command.ExecuteDataReader())
                    {
                        if (reader == null)
                        {
                            return false;
                        }

                        if(reader.HasRows)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Log to file
                return false;
            }

            return false;
        }
    }
}
