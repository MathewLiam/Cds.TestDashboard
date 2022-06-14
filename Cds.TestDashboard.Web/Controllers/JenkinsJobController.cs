namespace Cds.TestDashboard.Web.Controllers
{
    using Cds.TestDashboard.Core.Models.Jenkins;
    using Cds.TestDashboard.Core.Models.Pages;
    using Cds.TestDashboard.Core.Workers.Interfaces;
    using JenkinsNET.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Umbraco.Cms.Core.Models.PublishedContent;
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Web.Common.Controllers;

    public class JenkinsJobController : RenderController
    {
        private readonly IJenkinsWorker _jenkinsWorker;

        private readonly IPublishedValueFallback _publishedValueFallback;

        public JenkinsJobController(ILogger<RenderController> logger, 
            ICompositeViewEngine compositeViewEngine, 
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback,
            IJenkinsWorker jenkinsWorker
            ) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _jenkinsWorker = jenkinsWorker;
            _publishedValueFallback = publishedValueFallback;
        }

        [NonAction]
        public override IActionResult Index() => throw new NotImplementedException();


        public async Task<IActionResult> Index(CancellationToken cancellationToken = default(CancellationToken))
        {
            string jobName = (string)CurrentPage.GetProperty("jobName").GetValue();

            IJenkinsJob job = await _jenkinsWorker.GetJobAsync(jobName, cancellationToken);

            var model = new JenkinsJobPage(CurrentPage, _publishedValueFallback);

            switch (job.Class)
            {

                case "hudson.model.FreeStyleProject":
                    model.Job = await _jenkinsWorker.GetJobAsync<JenkinsFreeStyleJob>(jobName, cancellationToken);
                    model.Durations = await _jenkinsWorker.GetDurationsAsync(jobName, cancellationToken);
                    model.LastBuild = new JenkinsTestResult(await _jenkinsWorker.GetBuildAsync<JenkinsBuildBase>(jobName, ((JenkinsFreeStyleJob)model.Job).LastBuild.Number.Value, cancellationToken));

                    return View("~/Views/Jenkins/JenkinsFreeStyleJob.cshtml", model);

                default:
                    return BadRequest();

            }
        }
    }
}
