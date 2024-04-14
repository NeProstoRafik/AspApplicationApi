using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace AspApplication.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActivityType
{
    [Display(Name = "доклад")]
    Report,
    [Display(Name = "мастеркласс")]
    Masterclass,
    [Display(Name = "дискуссия")]
    Discussion,
}
