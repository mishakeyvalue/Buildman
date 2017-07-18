using Buildman.Jenkins.Models;
using JenkinsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildman.Jenkins.Managers
{
    public class JenkinsManager : IJenkinsManager
    {
        private readonly Client _client;

        public JenkinsManager()
        {
            var client = Client.Create("http://mitutee.tech:8080", "mitutee", "oJolgolo243JE");

            _client = client;            
        }

        public async Task<IEnumerable<JobModel>> GetJobsAsync()
        {
            IEnumerable<Job> jobs = await _client.GetJobsAsync();
            return jobs.Select(MapJobToJobModel);

            JobModel MapJobToJobModel(Job persistenceModel)
            {
                Console.WriteLine(persistenceModel.parameters.Count > 0 ? persistenceModel.parameters[0].description : "empty");
                return new JobModel()
                {
                    DisplayName = persistenceModel.name,
                    Name = persistenceModel.name,
                    Description = persistenceModel.description,
                    SubJobs = persistenceModel.SubJobs is null ? new JobModel[0] : persistenceModel.SubJobs.Select(MapJobToJobModel)
                };
            }
        }

        public async Task BuildJobAsync(string jobName)
        {
            await _client.GetJob(jobName).BuildAsync();
        }
    }
}
