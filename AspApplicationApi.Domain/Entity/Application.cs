using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Domain.Entity
{
    public class Application
    {
        [Required]
        public Guid Autor { get; set; }
        [Required]
        public Enum.Type Type { get; set; }
        [Required]
        public string Name { get; set; }    
        public string? Description { get; set; }
        [Required]
        public string Outline { get; set; }
       
      
    }
}
