using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Applications.Logging
{
    public static class LoggingFactory
    {
        public static Log CreateLog(string type, string text, string date)
        {
            LogLevel logType;
            if (Enum.TryParse(type, out logType))
            {

            }
            else
            {
                logType = LogLevel.Info;
            }

            Log log = new()
            {
                Type = logType,
                Text = text,
                Date = date
            };

            return log;
        }
    }
}
