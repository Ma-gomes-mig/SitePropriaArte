using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; //Mapeamento
using Data.SitePropriaArte.Entidades; //classe de entidades

namespace Data.SitePropriaArte.Mapping
{
    /// <summary>
    /// Classe de mapeamento da entidade Quadro
    /// </summary>
    public class QuadroMap : ClassMap<Quadro>
    {
        public QuadroMap()
        {
            Table("Quadro"); //Nome da tabela...

            //Chave primaria
            Id(q => q.IdQuadro, "IdQuadro").GeneratedBy.Identity();

            //demais propriedades...
            Map(q => q.Imagem, "Imagem").Length(100).Not.Nullable();
            Map(q => q.Nome, "Nome").Length(50).Not.Nullable();
            Map(q => q.Descricao, "Descricao").Not.Nullable();
            Map(q => q.DataCriacao, "DataCriacao").Not.Nullable();

            //Chaves estrangeiras...
            References(q => q.Categoria).Column("IdCategoria"); //Foreign Key
            References(q => q.Usuario).Column("IdUsuario"); //Foreign Kyes
        }
    }
}
