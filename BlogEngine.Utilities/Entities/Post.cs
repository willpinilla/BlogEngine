using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Utilities.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int WriterId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? EditorId { get; set; }
        public string? EditorComments { get; set; }
        public DateTime? RevisionDate { get; set; }
        public string Status { get; set; }

        [ForeignKey("WriterId")]
        public virtual User Writer { get; set; }

        [ForeignKey("EditorId")]
        public virtual User? Editor { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
