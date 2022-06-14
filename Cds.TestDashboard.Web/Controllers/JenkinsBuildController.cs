﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Web.Controllers
{
    using Cds.TestDashboard.Core.Models.Pages;
    using Cds.TestDashboard.Core.Workers.Interfaces;
    using JenkinsNET.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Umbraco.Cms.Core.Models.PublishedContent;
    using Umbraco.Cms.Core.Web;
    using Umbraco.Cms.Web.Common.Controllers;
    using Umbraco.Extensions;

    public class JenkinsBuildController : UmbracoPageController, IVirtualPageController
    {
        private readonly IJenkinsWorker _jenkinsWorker;

        private readonly IPublishedValueFallback _publishedValueFallback;

        private readonly IUmbracoContextAccessor _umbracoContextAccessor; 

        public JenkinsBuildController(ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback,
            IJenkinsWorker jenkinsWorker
            ) : base(logger, compositeViewEngine)
        {
            _jenkinsWorker = jenkinsWorker;
            _umbracoContextAccessor = umbracoContextAccessor;
            _publishedValueFallback = publishedValueFallback;
        }

        public IPublishedContent FindContent(ActionExecutingContext actionExecutingContext)
        {
            if (_umbracoContextAccessor.TryGetUmbracoContext(out IUmbracoContext umbracoContext))
            {
                var home = umbracoContext.Content.GetAtRoot().First();

                if (home != null)
                {
                    return home.ChildrenOfType("jenkinsBuild").First();
                } 
            }

            return null;
        }

        [Route("[Controller]/{jobName}/{buildNumber}")]
        [HttpGet]
        public async Task<IActionResult> Index(string jobName, int buildNumber, string? tab = "overview", CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var build = await _jenkinsWorker.GetBuildAsync<JenkinsBuildBase>(jobName, buildNumber, cancellationToken);

            var model = new JenkinsBuildPage(CurrentPage, _publishedValueFallback, build)
            {
                ConsoleHtml = await _jenkinsWorker.GetBuildConsoleHtmlAsync(jobName, buildNumber, cancellationToken),
                Tab = tab,
                JobName = jobName,
            };

            return View("~/Views/Jenkins/Build/JenkinsBuild.cshtml", model);
        }

        [Route("[Controller]/{jobName}/{buildNumber}/OverviewTab")]
        [HttpGet]
        public async Task<IActionResult> OverviewTab(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var build = await _jenkinsWorker.GetBuildAsync<JenkinsBuildBase>(jobName, buildNumber, cancellationToken);

            var model = new JenkinsBuildPage(CurrentPage, _publishedValueFallback, build)
            {
                ConsoleHtml = await _jenkinsWorker.GetBuildConsoleHtmlAsync(jobName, buildNumber, cancellationToken),
                JobName = jobName,
            };

            return View("~/Views/Jenkins/Build/Partials/_overviewTab.cshtml", model);
        }


        [Route("[Controller]/{jobName}/{buildNumber}/ConsoleTab")]
        [HttpGet]
        public async Task<IActionResult> ConsoleTab(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var build = await _jenkinsWorker.GetBuildAsync<JenkinsBuildBase>(jobName, buildNumber, cancellationToken);

            var model = new JenkinsBuildPage(CurrentPage, _publishedValueFallback, build)
            {
                ConsoleHtml = await _jenkinsWorker.GetBuildConsoleHtmlAsync(jobName, buildNumber, cancellationToken),
                JobName = jobName,
            };

            return PartialView("~/Views/Jenkins/Build/Partials/_consoleTab.cshtml", model);
        }
    }
}
