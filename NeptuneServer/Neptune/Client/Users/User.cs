﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Neptune.Client.Users
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string FullName { get; set; }
        public string Identifier { get; set; }
        public string Sid { get; set; }
        public string AuthToken { get; set; }
    }
}
