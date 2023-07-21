using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client.Applications.Logging
{
    public class Log
    {
        public LogLevel Type { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}
