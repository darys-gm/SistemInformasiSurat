using System;

namespace SistemInformasiSurat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NamaLengkap { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Properti tambahan untuk tampilan
        public string DisplayName => $"{NamaLengkap} ({Username})";
        public string RoleDisplay => RoleName ?? "User";
    }
}