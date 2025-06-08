using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogoSphere.Models
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; } = String.Empty;

        [ForeignKey("PostId")]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}