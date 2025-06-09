using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Domain.Entities;

public class ModelType:Entity
{
    public string Name { get; set; }
    
    public List<Model> Models { get; set; } = new();
}