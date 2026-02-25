namespace Application.DTOs
{
    public record SubmitStudentExamRequest(Guid studentId, List<SubmitAnswerDto> answers);
    public record SubmitAnswerDto(
    Guid QuestionId,
    Guid? ChoiceId,
    string? EssayAnswer
);
}
