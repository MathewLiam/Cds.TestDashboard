namespace Cds.TestDashboard.Core.Workers.Interfaces
{
    using JenkinsNET.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJenkinsWorker
    {
        Task<JenkinsJobBase> GetJobAsync(string jobName, CancellationToken cancellationToken = default(CancellationToken));

        Task<IDictionary<int, long>> GetDurationsAsync(string jobName, CancellationToken cancellationToken = default(CancellationToken));

        Task<T> GetJobAsync<T>(string jobName, CancellationToken cancellationToken = default(CancellationToken)) where T : JenkinsJobBase;

        Task<T> GetBuildAsync<T>(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken)) where T : JenkinsBuildBase;

        Task<string> GetBuildConsoleHtmlAsync(string jobName, int buildNumber, CancellationToken cancellationToken = default(CancellationToken));
    }
}
