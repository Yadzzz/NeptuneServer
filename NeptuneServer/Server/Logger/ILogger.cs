﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptuneServer.Server.Logger
{
    public interface ILogger
    {
        public void Log(string message);
        public void LogWarning(string message);
        public void LogError(string message);
    }
}
