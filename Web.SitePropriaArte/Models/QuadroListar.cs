using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Mapeamento
using Web.SitePropriaArte.Validators;
using Web.SitePropriaArte.Models;

namespace Web.SitePropriaArte.Models
{

    public class _QuadroModelListar
    {
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Datacriacao { get; set; }
    }
}