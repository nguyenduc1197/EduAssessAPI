
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ExamQuestion : BaseEntity
    {
        public Guid ExamId { get; set; }
        [ForeignKey(nameof(ExamId))]
        public Exam? Exam { get; set; }

        public Guid QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question? Question { get; set; }
    }
}
