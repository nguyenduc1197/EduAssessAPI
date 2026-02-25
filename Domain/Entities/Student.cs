using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public DateTime? DateOfBirth { get; set; } = null;

        public Guid SchoolClassId { get; set; }
        [ForeignKey(nameof(SchoolClassId))]
        public SchoolClass? SchoolClass { get; set; }

        public Account? Account { get; set; }
    }
}
