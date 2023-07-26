namespace webAPI.Entity.Request
{
    public class JobCreateRequest
    {
        public string JobType { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; } = string.Empty;
    }
}
