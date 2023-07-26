
using webAPI.Models.Base;

namespace webAPI.Entity
{
    public class Job : EntityBase
    {
        public string JobType { get; set; } = string.Empty;

        public string JobName { get; set; } = string.Empty;

        public string JobDescription { get; set; } = string.Empty;
    }
}
