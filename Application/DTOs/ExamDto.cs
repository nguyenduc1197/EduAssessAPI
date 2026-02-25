using Domain.Entities;

namespace Application.DTOs
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
