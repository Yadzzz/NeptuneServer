using NeptuneServer.Neptune.Client.Applications;
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
            if (UsersFactory.TryGetUser("2a60314f-5daf-4d9d-8b03-5d1973a36277", "393be0e4-5aa5-4b5e-b915-3242085ea087", out User user))
            {
                Assert.IsTrue(user != null);

                Assert.AreEqual(user.Id, 1);
                Assert.AreEqual(user.Username, "Yad");

                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
