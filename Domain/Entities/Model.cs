using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("models")]
public class Model
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("identifier")]
    public string Identifier { get; set; }

    [Required] [Column("temperature")] public double Temperature { get; set; } = 0.7;
   
    
    [Column("environment_variable")]
    public string EnvironmentVariable { get; set; }
    
    [Required]
    [Column("model_type_id")]
    public int ModelTypeId { get; set; }

    [ForeignKey("ModelTypeId")]
    public ModelType Provider { get; set; } = null!;
    
    public List<Thread> Threads { get; set; } = new();
}