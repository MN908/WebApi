namespace webAPI.Entity.Request
{
    public class JobUpdateRequest
    {
        public Guid Id { get; set; }
        public string JobType { get; set; } 

        public string JobName { get; set; } 

        public string JobDescription { get; set; }
    }
}
