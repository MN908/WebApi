using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace webAPI.Models.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
