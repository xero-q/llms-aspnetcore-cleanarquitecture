using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Domain.Entities;

public class Thread:Entity
{
    public string Title { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int ModelId { get; set; }

    public Model Model { get; set; } = null!;

    public int UserId { get; set; }

    public User User { get; set; } = null!;
    
    public List<Prompt> Prompts { get; set; } = new();
}