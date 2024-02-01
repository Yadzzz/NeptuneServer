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
            if (OrganizationFactory.TryGetOrganization("6dc66ac4-8a33-45c9-808f-de1127f6d4d5", "6767b5cf-d8ad-4a56-8c73-c75970df44d9", out Organization organization))
            {
                Assert.IsTrue(organization != null);

                Assert.AreEqual(organization.Id, 2);
                Assert.AreEqual(organization.UserId, 1);

                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void IsAllowedUser()
        {
            if (OrganizationFactory.IsAllowedUser(1, 2))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
