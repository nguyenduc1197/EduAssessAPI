namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IQuestionRepository Questions { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
