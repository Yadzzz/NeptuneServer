using NeptuneServer.Neptune.Applications;
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
        public Application Application { get; set; }

        public Client(User user, Application application)
        {
            this.User = user;
            this.Application = application; ;
        }
    }
}
