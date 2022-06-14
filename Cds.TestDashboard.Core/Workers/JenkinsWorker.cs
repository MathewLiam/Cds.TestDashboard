namespace Cds.TestDashboard.Core.Workers
{
    using Cds.TestDashboard.Core.Config;
    using Cds.TestDashboard.Core.Factories.Interfaces;
    using Cds.TestDashboard.Core.Workers.Interfaces;
    using JenkinsNET;
    using JenkinsNET.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class JenkinsWorker : WorkerBase, IJenkinsWorker
    {

        private readonly IJenkinsClientFactory _jenkinsClientFactory;

        private readonly IOptions<IJenkinsContext> _jenkinsContext;

        private readonly IHtmlWorker _htmlWorker;

        public JenkinsWorker(ILogger<JenkinsWorker> logger, IOptions<JenkinsConfig> jenkinsContext, IJenkinsClientFactory jenkinsClientFactory, IHtmlWorker htmlWorker) : base(logger)
        {
            _jenkinsClientFactory = jenkinsClientFactory;
            _jenkinsContext = jenkinsContext;
            _htmlWorker = htmlWorker;
        }

        public Task<JenkinsJobBase> GetJobAsync(string jobName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var _jenkinsClient = _jenkinsClientFactory.CreateClient(_jenkinsContext.Value);

            return _jenkinsClient.Jobs.GetAsync<JenkinsJobBase>(jobName, cancellationToken);
        }

        public Task<T> GetJobAsync<T>(string jobName, CancellationToken cancellationToken = default(CancellationToken)) where T : JenkinsJobBase
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(jobName);
            }

            var _jenkinsClient = _jenkinsClientFactory.CreateClient(_jenkinsContext.Value);

            return _jenkinsClient.Jobs.GetAsync<T>(jobName, cancellationToken);
        }

        public async Task<IDictionary<int, long>> GetDurationsAsync(string jobName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            Dictionary<int,long> durations = new Dictionary<int, long>();

            var _jenkinsClient = _jenkinsClientFactory.CreateClient(_jenkinsContext.Value);

            var job = await _jenkinsClient.Jobs.GetAsync<JenkinsFreeStyleJob>(jobName, cancellationToken);

            foreach (var build in job.Builds)
            {
                var buildResult = await _jenkinsClient.Builds.GetAsync<JenkinsBuildBase>(jobName, build.Number.ToString());
                
                if (buildResult.Duration.HasValue && buildResult.Number.HasValue)
                {
                    durations.Add(buildResult.Number.Value, buildResult.Duration.Value);
                }
            }

            return durations;
        }


        public Task<T> GetBuildAsync<T>(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken)) where T : JenkinsBuildBase
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var _jenkinsClient = _jenkinsClientFactory.CreateClient(_jenkinsContext.Value);

            return _jenkinsClient.Builds.GetAsync<T>(jobName, buildNumber.ToString(), cancellationToken);
        }


        public async Task<string> GetBuildConsoleHtmlAsync(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            var _jenkinsClient = _jenkinsClientFactory.CreateClient(_jenkinsContext.Value);

            return _htmlWorker.GetElementById(await _jenkinsClient.Builds.GetConsoleHtmlAsync(jobName, buildNumber.ToString(), cancellationToken), "main-panel");
        }

    }
}
