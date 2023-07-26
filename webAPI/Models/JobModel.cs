using webAPI.Entity;
using webAPI.Models.Base;

namespace webAPI.Models
{
    public class JobModel : EntityBase
    {
        public string JobType { get; set; } = string.Empty;

        public string JobName { get; set; } = string.Empty;

        public string JobDescription { get; set; } = string.Empty;

    }
}
