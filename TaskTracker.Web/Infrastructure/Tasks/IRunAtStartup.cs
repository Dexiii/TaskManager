﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Web.Infrastructure.Tasks
{
    public interface IRunAtStartup
    {
        void Execute();
    }
}
