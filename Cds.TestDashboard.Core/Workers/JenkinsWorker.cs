namespace Cds.TestDashboard.Core.Workers
{
    using Cds.TestDashboard.Core.Workers.Interfaces;
    using JenkinsClient;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class JenkinsWorker : IJenkinsWorker
    {
        private readonly Client _jenkinsClient;

        public JenkinsWorker(Client jenkinsClient)
        {
            _jenkinsClient = jenkinsClient;
        }

        public Task<List<Job>> GetAsync()
        {
            return _jenkinsClient.GetJobsAsync();
        }


        public Job GetJob(string jobName)
        {
            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            return _jenkinsClient.GetJob(jobName);
        }

    }
}
