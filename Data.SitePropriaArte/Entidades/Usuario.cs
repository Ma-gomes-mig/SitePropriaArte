using Data.SitePropriaArte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.SitePropriaArte.Entities
{
    /// <summary>
    /// Classe de entidade
    /// </summary>
    public class Usuario
    {
        public virtual int IdUsuario { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        //Associação -> Ter muitos
        public virtual ICollection<Quadro> Quadro { get; set; }
    }
}
