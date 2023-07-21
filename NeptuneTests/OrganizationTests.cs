using NeptuneServer.Neptune.Client.Organization;
using NeptuneServer.Neptune.Client.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneTests
{
    public class OrganizationTests
    {
        [Test]
        public void TryGetOrganization()
        {
            if (OrganizationFactory.TryGetOrganization("123", "123", out Organization organization))
            {
                Assert.IsTrue(organization != null);

                Assert.AreEqual(organization.Id, 1);
                Assert.AreEqual(organization.UserId, 1);

                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
