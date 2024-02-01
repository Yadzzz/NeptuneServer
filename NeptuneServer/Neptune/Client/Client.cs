using NeptuneServer.Neptune.Client.Applications;
using NeptuneServer.Neptune.Client.Organization;
using NeptuneServer.Neptune.Client.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client
{
    public class Client
    {
        public User User { get; set; }
        public Organization.Organization Organization { get; set; }
        public Application Application { get; set; }

        public Client(User user, Application application, Organization.Organization organization)
        {
            this.User = user;
            this.Application = application; ;
            this.Organization = organization;
        }

        public bool IsAuthenticated(out string error)
        {
            error = string.Empty;

            if (this.User == null)
            {
                error = "User not Authenticated";
                return false;
            }

            if (this.Organization == null)
            {
                error = "Organization not Authenticated";
                return false;
            }

            if (this.Application == null)
            {
                error = "Application not Authenticated";
                return false;
            }

            return true;
        }
    }
}
