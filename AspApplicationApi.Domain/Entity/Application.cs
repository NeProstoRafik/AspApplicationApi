﻿using System.ComponentModel.DataAnnotations;

namespace AspApplication.Domain.Entity;
public class Application
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid Autor { get; set; }
    public Enum.ActivityType? Type { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }
    [MaxLength(1000)]
    public string? Outline { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public bool Submit { get; set; } = false;
}
