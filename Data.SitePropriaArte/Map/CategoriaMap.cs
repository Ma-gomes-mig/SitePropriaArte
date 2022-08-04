using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; //Mapeamento
using Data.SitePropriaArte.Entidades; //Classes de entidade

namespace Data.SitePropriaArte.Mapping
{
    /// <summary>
    /// Classe de mapeamento da entidade Categoria
    /// </summary>
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("Categoria"); //nome da tabela..
                                //chave primaria..
            Id(c => c.IdCategoria, "IdCategoria").GeneratedBy.Identity();

            //demais atributos...
            Map(c => c.Nome, "Nome").Length(50).Not.Nullable();

            //Relacionamentos...
            HasMany(c => c.Quadro).KeyColumn("IdCategoria").Inverse();
        }
    }
}

