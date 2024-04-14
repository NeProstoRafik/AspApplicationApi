using AspApplication.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace AspApplication.Application.Contracts;

public class ApplicationDTOUpdate
{
 
    public ActivityType? Type { get; set; }   
    public string? Name { get; set; }
    public string? Description { get; set; }   
    public string? Outline { get; set; }
}
