using Cds.TestDashboard.Core.Factories.Interfaces;
using JenkinsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Core.Factories
{
    public sealed class JenkinsClientFactory : IJenkinsClientFactory
    {
        public IJenkinsClient CreateClient(IJenkinsContext context)
        {
            return new JenkinsClient()
            {
                BaseUrl = "http://18.130.98.25/",
                UserName = "mathew mcpherson",
                ApiToken = "110c576a824d3e22e1b318c80c1e946584"
            };
        }
    }
}
