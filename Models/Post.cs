namespace NutriSpace.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navegación
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
