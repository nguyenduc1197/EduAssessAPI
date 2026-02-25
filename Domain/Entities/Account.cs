using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        [MaxLength(200)]
        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
