using Data.SitePropriaArte.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SitePropriaArte.Entidades
{
    public class Categoria
    {
        public virtual int IdCategoria { get; set; }
        public virtual string Nome { get; set; }
        
        //Relacionamento -> Ter muitos
        public virtual ICollection<Quadro> Quadro { get; set; }
    }
}
