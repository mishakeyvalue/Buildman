using System.Collections.Generic;
using System.Threading.Tasks;
using JenkinsClient;
using Buildman.Jenkins.Models;

namespace Buildman.Jenkins.Managers
{
    public interface IJenkinsManager
    {
        Task<IEnumerable<JobModel>> GetJobsAsync();
        Task BuildJobAsync(string jobName);
    }
}