using AspApplication.Domain.Enum;

namespace AspApplication.Application.Contracts;

public class ApplicationResponce
{
    public Guid Id { get; set; }
    public Guid Author { get; set; }
    public ActivityType? Type { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Outline { get; set; }
}
