using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Entities
{
    [Table("tb_AnuncioWebmotors")]
    public class AnuncioWebMotors
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45)]
        [Required]
        public string Marca { get; set; }

        [MaxLength(45)]
        [Required]
        public string Modelo { get; set; }

        [MaxLength(45)]
        [Required]
        public string Versao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Quilometragem { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Observacao { get; set; }
    }
}
