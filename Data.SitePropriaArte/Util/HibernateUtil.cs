using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Data.SitePropriaArte.Mapping;

namespace Data.SitePropriaArte.Util
{
    /// <summary>
    /// Classe para configuração da SessionFactory
    /// </summary>
    public class HibernateUtil
    {
        private static ISessionFactory factory; //null
        public static ISessionFactory GetSessionFactory()
        {
            if (factory == null) //singleton...
            {
                factory = Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(
                ConfigurationManager.ConnectionStrings
                ["SitePropriaArte"].ConnectionString
                )
                ).Mappings(m => m.FluentMappings.
                AddFromAssemblyOf<UsuarioMap>()).
                BuildSessionFactory();
            }
            return factory;
        }
    }
}