using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SchoolYear
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? Start { get; set; } = null;

        public DateTime? End { get; set; } = null;

        public ICollection<SchoolClass>? Classes { get; set; }
    }
}
