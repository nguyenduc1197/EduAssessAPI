namespace Domain.Entities
{
    public class Subject : BaseEntity
    {
        public ICollection<SchoolClassSubject>? SchoolClassSubjects { get; set; }
    }
}
