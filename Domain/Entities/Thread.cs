using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Table("threads")]
[Index(nameof(Title), IsUnique = true)]
public class Thread
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("title")]
    public string Title { get; set; }
    
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [Column("model_id")]
    public int ModelId { get; set; }

    public Model Model { get; set; } = null!;

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    public User User { get; set; } = null!;
    
    public List<Prompt> Prompts { get; set; } = new();
}