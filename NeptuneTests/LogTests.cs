using NeptuneServer.Neptune.Applications;
using NeptuneServer.Neptune.Applications.Logging;
using NeptuneServer.Neptune.Client.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneTests
{
    public class LogTests
    {
        [Test]
        public void CreateLog()
        {
            Log log = LoggingFactory.CreateLog("info", "log text", DateTime.Now.ToString());

            Assert.IsNotNull(log);
            Assert.AreEqual(log.Type, LogLevel.Info);
            Assert.AreEqual(log.Text, "log text");

            Assert.Pass();
        }
    }
}
