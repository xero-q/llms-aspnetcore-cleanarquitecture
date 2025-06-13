using SharedKernel;

namespace Domain.Entities;

public sealed class User:Entity
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public bool IsAdmin { get; set; }
    
    public List<Thread> Threads { get; set; } = new();
}