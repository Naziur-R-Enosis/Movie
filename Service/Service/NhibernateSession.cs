using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class NhibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var bookConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Movie.hbm.xml");
            var actorConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Actor.hbm.xml");
            configuration.AddFile(bookConfigurationFile);
            configuration.AddFile(actorConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}