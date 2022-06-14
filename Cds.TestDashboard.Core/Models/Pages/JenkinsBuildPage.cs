using JenkinsNET.Models;
using System;
using System.Linq;
using System.Xml.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using static Cds.TestDashboard.Core.Constants.JenkinsConstants;

namespace Cds.TestDashboard.Core.Models.Pages
{
    public class JenkinsBuildPage : PublishedContentModel
    {
        public JenkinsBuildPage(IPublishedContent content, IPublishedValueFallback publishedValueFallback, JenkinsBuildBase build) : base(content, publishedValueFallback)
        {
            Build = build;
        }

        public JenkinsBuildBase Build;

        public JenkinsAction TestAction => this.Build.Actions.ToList().Where(m => !string.IsNullOrWhiteSpace(m.Class) && m.Class.Equals(TestResultActionKey)).FirstOrDefault();

        public int FailCount => Int32.Parse(((XElement)this.TestAction.Node).Element("failCount").Value);

        public int PassCount => Int32.Parse(((XElement)this.TestAction.Node).Element("totalCount").Value) - (FailCount + SkipCount);

        public int SkipCount => Int32.Parse(((XElement)this.TestAction.Node).Element("skipCount").Value);

        public string ConsoleHtml { get; set; }

        public string Tab { get; set; }

        public string JobName { get; set; }
    }
}
