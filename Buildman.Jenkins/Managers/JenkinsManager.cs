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
            var client = Client.Create("http://mitutee.tech:8080", "", "");

            _client = client;            
        }

        public async Task<IEnumerable<JenkinsClient.Job>> GetJobsAsync()
        {
            return await _client.GetJobsAsync();
        }


    }
}
