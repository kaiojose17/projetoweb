using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Entities.DTO
{
    [NotMapped]
    public class VersionDTO
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
    }
}
