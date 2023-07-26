using webAPI.Models.Base;

namespace webAPI.Models
{
    public class UserModel : EntityBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Guid JobId { get; set; }
    }
}
