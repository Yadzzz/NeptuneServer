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
        public static bool TryGetApplication(int appId, int orgId, out Application application)
        {
            application = null;

            try
            {
                using (var command = new DatabaseCommand())
                {
                    command.SetCommand("SELECT * FROM applications WHERE id = @id AND organization_id = @orgid");
                    command.AddParameter("id", appId);
                    command.AddParameter("orgid", orgId);

                    using (var reader = command.ExecuteDataReader())
                    {
                        if (reader == null)
                        {
                            return false;
                        }

                        if (reader.HasRows)
                        {
                            application = new Application
                            {
                                Id = appId,
                                OrganizationId = orgId
                            };

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
