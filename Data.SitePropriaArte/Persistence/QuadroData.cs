using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Data.SitePropriaArte.Util;
using Data.SitePropriaArte.Generics;
using Data.SitePropriaArte.Entidades;
using Data.SitePropriaArte.Entities;

namespace Data.SitePropriaArte.Persistence
{
    /// <summary>
    /// Classe de persistencia para a entidade Quadro
    /// </summary>
    public class QuadroData : GenericData<Quadro>
    {
        public List<Quadro> ListarQuadros(int Idusuario)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //SQL -> select mostrando todos os quadros == idUsuario
                var query = from q in s.Query<Quadro>()
                            where q.Usuario.IdUsuario == Idusuario
                            select q;

                //retornar a lista de quadro ...
                return query.List<Quadro>;
            }
        }
    }
}
