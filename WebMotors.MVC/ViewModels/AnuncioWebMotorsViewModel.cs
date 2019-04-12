using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMotors.MVC.ViewModels
{
    public class AnuncioWebMotorsViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45, ErrorMessage = "Máximo {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo Marca")]
        public string Marca { get; set; }

        [MaxLength(45, ErrorMessage = "Máximo {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo Modelo")]
        public string Modelo { get; set; }

        [MaxLength(45, ErrorMessage = "Máximo {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo Versao")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ano")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quilometragem")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Preencha o campo Observacao")]
        public string Observacao { get; set; }
    }
}