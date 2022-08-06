using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Mapeamento
using Web.SitePropriaArte.Validators;

namespace Web.SitePropriaArte.Models
{
    public class QuadroModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do quadro.")]
        [Display(Name = "informe o nome do Quadro: ")] //Label
        public string Nome { get; set; } //campo

        [Required(ErrorMessage = "Por favor, Informe a descrição do quadro. ")]
        [Display(Name = "Informe a descrição do quadro: ")]
        public string Descricao { get; set; } //campo

        [Required(ErrorMessage = "Por favor, informe a data de que o quadro foi pintado. ")]
        [Display(Name = "Informe a data que o quadro foi pintado: ")]
        public DateTime DataCriacao { get; set; }
    }
}