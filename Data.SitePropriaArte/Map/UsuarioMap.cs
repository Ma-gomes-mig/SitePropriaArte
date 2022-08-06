using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; //mapeamento
using Data.SitePropriaArte.Entities; //classes de entidade

namespace Data.SitePropriaArte.Mapping
{
    /// <summary>
    /// Classe de mapeamento da entidade Usuario
    /// </summary>
    public class UsuarioMap : ClassMap<Usuario>
    {
        //construtor.. [ctor] + 2x[tab]
        public UsuarioMap()
        {
            //nome da tabela
            Table("Usuario"); //opcional
                              //chave primaria..
            Id(u => u.IdUsuario, "IdUsuario").GeneratedBy.Identity();
            //demais atributos...
            Map(u => u.Nome, "Nome").Length(50).Not.Nullable();
            Map(u => u.Email, "Email").Length(30).Not.Nullable().Unique();
            Map(u => u.Senha, "Senha").Length(40).Not.Nullable();
            Map(u => u.DataCadastro, "DataCadastro").Not.Nullable();
        }
    }
}