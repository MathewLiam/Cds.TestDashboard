using Cds.TestDashboard.Core.Models.Jenkins;
using JenkinsNET.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Cds.TestDashboard.Core.Models.Pages
{
    public sealed class JenkinsJobPage : PublishedContentModel
    {
        public JenkinsJobPage(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public IJenkinsJob Job { get; set; }

        public IDictionary<int, long> Durations { get; set; }

        public JenkinsTestResult LastBuild { get; set; }
    }
}
