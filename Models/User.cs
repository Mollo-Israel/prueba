using Microsoft.Extensions.Hosting;

namespace NutriSpace.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navegación
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
