using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SchoolClass: BaseEntity
    {
        public Guid HomeRoomTeacherId { get; set; }

        [ForeignKey(nameof(HomeRoomTeacherId))]
        public Teacher? HomeRoomTeacher { get; set; }

        public Guid SchoolYearId { get; set; }

        [ForeignKey(nameof(SchoolYearId))]
        public SchoolYear? SchoolYear { get; set; }

    }
}
