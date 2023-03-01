using WebEnterpriseProject.Enums;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebEnterpriseProject.Models
{
	public class Comment
		{
		    [Key]
	            public int Id { get; set; }
		    [Required]
		    [ForeignKey("Post")]
		    public int PostId {get; set;}
		    public Post Post { get; set; }
		    [Required]
		    [ForeignKey("User")]
		    public int UserId {get; set;}
		    public User User { get; set; }
		    public CommentStatus Status { get; set; } = CommentStatus.Comment;
		    [Required(ErrorMessage = "You need to add Comment ...")]
		    [StringLength(255)]
		    public string Content { get; set; }
		    public DateTime CreatedAt { get; set; } = DateTime.Now;
		}
}
