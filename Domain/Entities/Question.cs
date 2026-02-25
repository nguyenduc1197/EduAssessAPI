using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Question : BaseEntity
    {
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty; 

        public ICollection<Choice>? Choices { get; set; }
    }
}
