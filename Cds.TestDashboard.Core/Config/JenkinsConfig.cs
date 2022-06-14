using JenkinsNET;
using JenkinsNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Core.Config
{
    public sealed class JenkinsConfig : IJenkinsContext
    {
        public string BaseUrl { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ApiToken { get; set; }

        public JenkinsCrumb Crumb => throw new NotImplementedException();
    }
}
