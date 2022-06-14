using JenkinsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Core.Factories.Interfaces
{
    public interface IJenkinsClientFactory
    {
        IJenkinsClient CreateClient(IJenkinsContext context);
    }
}
