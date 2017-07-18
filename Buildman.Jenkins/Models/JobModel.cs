using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildman.Jenkins.Models
{
    public class JobModel
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<JobModel> SubJobs { get; set; }
    }
}
