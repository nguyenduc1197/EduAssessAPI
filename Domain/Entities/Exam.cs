
namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public DateTime? Start { get; set; } = null;

        public DateTime? End { get; set; } = null;

        public Subject? Subject { get; set; }

        public SchoolClass? SchoolClass { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
