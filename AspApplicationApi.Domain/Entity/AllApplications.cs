using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Domain.Entity
{
    public class AllApplications
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Autor { get; set; }      
        public Enum.Type Type { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [MaxLength(1000)]
        public string Outline { get; set; }      
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public bool Submit { get; set; }=false;
    }
}
