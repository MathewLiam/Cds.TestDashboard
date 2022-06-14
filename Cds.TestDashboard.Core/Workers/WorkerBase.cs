using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Core.Workers
{
    public abstract class WorkerBase
    {
        protected readonly ILogger<WorkerBase> Logger;

        public WorkerBase(ILogger<WorkerBase> logger)
        {
            Logger = logger;
        }
    }
}
