using System.ComponentModel.DataAnnotations;

namespace zlobek.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int RoleId { get; set; }
    }
}
