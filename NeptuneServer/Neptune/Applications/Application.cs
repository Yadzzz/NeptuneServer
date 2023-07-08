using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NeptuneServer.Neptune.Applications.Logging;
using NeptuneServer.Neptune.Client.Users;
using NeptuneServer.Server.Database;
using static System.Net.Mime.MediaTypeNames;

namespace NeptuneServer.Neptune.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }

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
