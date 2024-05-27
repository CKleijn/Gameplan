using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameplanAPI.Shared.Abstractions
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private Guid _id;
        public Guid Id { get { return _id; } private set { _id = value; } }

        private DateTime? _updatedAt;
        public DateTime? UpdatedAt { get { return _updatedAt; } set { _updatedAt = value; } }

        private DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt { get { return _createdAt; } }
    }
}
