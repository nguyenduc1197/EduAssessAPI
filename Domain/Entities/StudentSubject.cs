using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class StudentSubject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        public Guid SchoolClassSubjectId { get; set; }
        [ForeignKey(nameof(SchoolClassSubjectId))]
        public SchoolClassSubject? SchoolClassSubject { get; set; }

        public decimal? Score { get; set; }           
        public string? ExamSubmissionContent { get; set; } 
        public string? Feedback { get; set; }

        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
        public DateTime? DateGraded { get; set; }
    }
}
