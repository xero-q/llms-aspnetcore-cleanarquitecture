using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("prompts")]
public class Prompt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("prompt")]
    public string PromptText { get; set; }
    
    [Required]
    [Column("response")]
    public string Response { get; set; }
    
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [Column("thread_id")]
    public int ThreadId { get; set; }

    [ForeignKey("ThreadId")]
    public Thread Thread { get; set; } = null!;
}