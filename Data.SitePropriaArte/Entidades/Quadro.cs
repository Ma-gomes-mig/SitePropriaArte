using Data.SitePropriaArte.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SitePropriaArte.Entidades
{
    public class Quadro
    {
        public virtual int IdQuadro { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataCriacao { get; set; }

        //Relacionamentos (Associação)
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
