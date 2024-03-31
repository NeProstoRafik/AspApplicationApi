using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspApplicationApi.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        [Display(Name = "доклад")]
        Report,
        [Display(Name = "мастеркласс")]
        Masterclass,
        [Display(Name = "дискуссия")]
        Discussion,
    }
}
