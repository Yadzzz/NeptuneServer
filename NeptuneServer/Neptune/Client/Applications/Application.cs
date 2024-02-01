using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NeptuneServer.Neptune.Client.Applications.Logging;
using NeptuneServer.Neptune.Client.Users;
using NeptuneServer.Server.Database;
using static System.Net.Mime.MediaTypeNames;

namespace NeptuneServer.Neptune.Client.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }

        public void Log(Log log)
        {
            try
            {
                using (var command = new DatabaseCommand())
                {
                    command.SetCommand("INSERT INTO applications_logs (application_id, type, text, date) VALUES (@appid, @type, @text, @date)");
                    command.AddParameter("appid", this.Id);
                    command.AddParameter("type", log.Type.ToString());
                    command.AddParameter("text", log.Text);
                    command.AddParameter("date", log.Date);

                    command.ExecuteQuery();
                }
            }
            catch(Exception ex)
            {
                //Log to file
            }
        }
    }
}
