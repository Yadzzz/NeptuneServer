﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer
{
    public class NeptuneConfiguration
    {
        //Database
        public const string ConnectionString = "Server=127.0.0.1;Database=neptune;Uid=root;Pwd=Yadz1042!;";

        //Network
        public const int MaxSocketConnection = 1000;
    }
}
