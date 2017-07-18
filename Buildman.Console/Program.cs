using Buildman.Jenkins.Managers;
using Buildman.Jenkins.Models;
using System.Collections.Generic;
using System.Linq;

namespace Buildman.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IJenkinsManager manager = new JenkinsManager();
            PrintJobs(manager.GetJobsAsync().Result);

        }

        static void PrintJobs(IEnumerable<JobModel> jobs)
        {
            foreach (var job in jobs)
            {
                System.Console.WriteLine(job.Name);
                PrintJobs(job.SubJobs);

            }
        }
    }
}
