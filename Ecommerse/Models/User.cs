using System.ComponentModel.DataAnnotations;

namespace Ecommerse.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } = "user";

    }
}
