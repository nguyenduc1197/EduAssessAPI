using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Choice : BaseEntity
    {
        public Guid QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question? Question { get; set; }

        [MaxLength(1)]
        public string OptionLabel { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;
    }
}
