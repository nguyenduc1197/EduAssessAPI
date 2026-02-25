namespace Application.DTOs
{
    public record LoginResponse(string token, string role, string name);
}
