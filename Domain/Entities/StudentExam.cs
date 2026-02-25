using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class StudentExam
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Exam? Exam { get; set; }

        public Student? Student { get; set; }

        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public decimal? Score { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public ICollection<StudentExamAnswer>? Answers { get; set; }
    }
}
