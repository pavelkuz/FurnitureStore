using FurnitureStore.Models;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FurnitureStore.Models.Utils
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var NHibernateConfig = new Configuration();
                    NHibernateConfig.Configure(HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\hibernate.cfg.xml"));
                    NHibernateConfig.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\Mappings")));
                    _sessionFactory = NHibernateConfig.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}