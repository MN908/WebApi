using System.ComponentModel.DataAnnotations.Schema;
using webAPI.Models.Base;

namespace webAPI.Entity
{
    public class Users : EntityBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual required Job Job { get; set; }
    }
}
