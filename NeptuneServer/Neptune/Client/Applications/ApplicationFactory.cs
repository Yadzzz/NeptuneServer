using Google.Protobuf.WellKnownTypes;
using NeptuneServer.Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client.Applications
{
    public static class ApplicationFactory
    {
        public static bool TryGetApplication(string appIdentifier, int orgId, out Application application)
        {
            application = null;

            try
            {
                using (var command = new DatabaseCommand())
                {
                    command.SetCommand("SELECT * FROM applications WHERE identifier = @identifier AND organization_id = @orgid LIMIT 1");
                    command.AddParameter("identifier", appIdentifier);
                    command.AddParameter("orgid", orgId);

                    using (var reader = command.ExecuteDataReader())
                    {
                        if (reader == null)
                        {
                            return false;
                        }

                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                application = new Application
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    OrganizationId = orgId
                                };
                            }

                            return true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //Log to file
            }

            return application != null;
        }
    }
}
