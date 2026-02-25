using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Subject { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; } = null;
        public Account? Account { get; set; }

        public ICollection<SchoolClass>? Classes { get; set; }
    }
}
