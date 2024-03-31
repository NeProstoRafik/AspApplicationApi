using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Domain.ViewModel
{
    public class ApplicationDTO
    {
        [Required]
        public Guid Autor { get; set; }
        [Required]
        public Enum.Type Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Outline { get; set; }
    }
}
