namespace Application.DTOs
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<ChoiceDto> Choices { get; set; } = new();
    }
}
