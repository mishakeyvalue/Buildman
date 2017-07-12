using System.Collections.Generic;
using System.Threading.Tasks;
using JenkinsClient;

namespace Buildman.Jenkins.Managers
{
    public interface IJenkinsManager
    {
        Task<IEnumerable<Job>> GetJobsAsync();
    }
}