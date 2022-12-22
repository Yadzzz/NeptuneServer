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
    public class UsersTests
    {
        [Test]
        public void TryGetUser()
        {
            if (UsersFactory.TryGetUser("sadasdasdasd", out User user))
            {
                Assert.IsTrue(user != null);

                Assert.AreEqual(user.Id, 1);
                Assert.AreEqual(user.Username, "Yad");

                Assert.Pass();
            }
        }
    }
}
