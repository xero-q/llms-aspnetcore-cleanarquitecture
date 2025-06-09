using SharedKernel;

namespace Domain.Entities;

public class Prompt:Entity
{
   
    public string PromptText { get; set; }
    
    public string Response { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int ThreadId { get; set; }

    public Thread Thread { get; set; } = null!;
}