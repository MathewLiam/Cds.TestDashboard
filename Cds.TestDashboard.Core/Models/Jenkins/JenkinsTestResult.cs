using JenkinsNET.Models;
using System;
using System.Linq;
using static Cds.TestDashboard.Core.Constants.JenkinsConstants;
using System.Xml.Linq;

namespace Cds.TestDashboard.Core.Models.Jenkins
{
    public class JenkinsTestResult
    {
        public JenkinsTestResult(JenkinsBuildBase build)
        {
            this.Build = build;
        }

        public JenkinsBuildBase Build;

        public JenkinsAction TestAction => this.Build.Actions.ToList().Where(m => !string.IsNullOrWhiteSpace(m.Class) && m.Class.Equals(TestResultActionKey)).FirstOrDefault();

        public int FailCount => Int32.Parse(((XElement)this.TestAction.Node).Element("failCount").Value);

        public int PassCount => Int32.Parse(((XElement)this.TestAction.Node).Element("totalCount").Value) - (FailCount + SkipCount);

        public int SkipCount => Int32.Parse(((XElement)this.TestAction.Node).Element("skipCount").Value);
    }
}
