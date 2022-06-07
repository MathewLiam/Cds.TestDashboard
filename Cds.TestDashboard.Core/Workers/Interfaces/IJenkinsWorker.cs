namespace Cds.TestDashboard.Core.Workers.Interfaces
{
    using JenkinsClient;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJenkinsWorker
    {
        Task<List<Job>> GetAsync();

        Job GetJob(string jobName);
    }
}
