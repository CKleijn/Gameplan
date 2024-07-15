using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameplanAPI.Common.Implementations
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
