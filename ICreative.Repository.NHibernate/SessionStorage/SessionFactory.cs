
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace ICreative.Repository.NHibernate.SessionStorage
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static void Init()
        {
            string assemblyName = "Repository.NHibernate";
            FluentConfiguration config = Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString()))
    .Mappings(m => m.FluentMappings.AddFromAssembly(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly=>assembly.GetName().Name.Contains(assemblyName))));
                


            log4net.Config.XmlConfigurator.Configure();

            try
            {
                _sessionFactory = config.BuildSessionFactory();
            }
            catch ( Exception exx)
            {
                string eee = exx.InnerException.ToString();
            }
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer =
                                       SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }

}
