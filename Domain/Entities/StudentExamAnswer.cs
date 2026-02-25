using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class StudentExamAnswer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public StudentExam? StudentExam { get; set; }

        public Question? Question { get; set; }

        public Choice? Choice { get; set; }

        public string? EssayAnswer { get; set; }

        public decimal? Score { get; set; }
    }
}
