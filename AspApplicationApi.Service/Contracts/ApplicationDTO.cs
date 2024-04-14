using System.ComponentModel.DataAnnotations;
using AspApplication.Domain.Enum;

namespace AspApplication.Application.Contracts;

public class ApplicationDTO
{
  
    public Guid Author { get; set; }  
    public ActivityType? Type { get; set; }    
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }  
    [MaxLength(1000)]
    public string? Outline { get; set; }
}
