using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SchoolClassSubject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SchoolClassId { get; set; }
        [ForeignKey(nameof(SchoolClassId))]
        public SchoolClass? SchoolClass { get; set; }

        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public Subject? Subject { get; set; }
    }
}
