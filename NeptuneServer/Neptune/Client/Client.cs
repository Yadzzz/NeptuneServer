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

        public Client(User user)
        {
            this.User = user;
        }

        public bool IsAuthenticated(out string error)
        {
            error = string.Empty;

            if (this.User == null)
            {
                error = "User not Authenticated";
                return false;
            }

            return true;
        }
    }
}
