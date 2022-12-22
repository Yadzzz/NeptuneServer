using NeptuneServer.Neptune.Applications;
using NeptuneServer.Neptune.Client.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneTests
{
    public class ApplicationTests
    {
        [Test]
        public void TryGetApplication()
        {
            if (ApplicationFactory.TryGetApplication(1, 1, out Application application))
            {
                Assert.IsTrue(application != null);
                Assert.AreEqual(application.Id, 1);
                Assert.AreEqual(application.UserId, 1);

                Assert.Pass();
            }
        }
    }
}
