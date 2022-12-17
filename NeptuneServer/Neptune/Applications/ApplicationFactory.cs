using NeptuneServer.Server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Applications
{
    public static class ApplicationFactory
    {
        public static bool TryGetApplication(int appId, int userId, out Application application)
        {
            application = null;

            using (var command = new DatabaseCommand())
            {
                command.SetCommand("SELECT * FROM applications WHERE id = @id AND user_id = @userid");
                command.AddParameter("id", appId);
                command.AddParameter("userid", userId);

                using (var reader = command.ExecuteDataReader())
                {
                    if(reader == null)
                    {
                        return false;
                    }
                    
                    if(reader.HasRows)
                    {
                        application = new Application
                        {
                            Id = appId,
                            UserId = userId
                        };

                        return true;
                    }
                }
            }

            return application != null;
        }
    }
}
