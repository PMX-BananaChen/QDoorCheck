using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using NHibernate;
using NHibernate.Cfg;

namespace BO.DBAccess
{
    /// <summary>
    /// Summary description for SessionFactory
    /// </summary>
    public class SessionFactory
    {
        private static object _obj = new object();
        //private static object _obj1 = new object();

        private SessionFactory()
        {
            //
            // TODO: Add constructor logic here
            //            
        }

        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory Instance
        {
            get
            {
                if (_sessionFactory == null)
                {
                    lock (_obj)
                    {
                        if (_sessionFactory == null)
                        {
                            _sessionFactory = BuildSessionFactory();
                        }
                    }
                }

                return _sessionFactory;
            }
            set 
            {
                _sessionFactory = value;
            }
        }

        public static void Reset()
        {
            return;

            //if (_sessionFactory != null)
            //{
            //    ISession curSession = null;
            //    try
            //    {
            //        curSession = _sessionFactory.GetCurrentSession();
            //    }
            //    catch (Exception)
            //    { }

            //    if (null != curSession && curSession.IsOpen)
            //    {
            //        curSession.Clear();
            //        curSession.Close();
            //    }
            //    _sessionFactory.Evict(typeof(BO.Authority));
            //    _sessionFactory.Evict(typeof(BO.Person));
            //    _sessionFactory.Evict(typeof(BO.CheckLog));
            //    _sessionFactory.Dispose();
            //    _sessionFactory = null;
            //}
            //GC.Collect();
        }

        public static ISessionFactory BuildSessionFactory()
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            cfg.Configure(basePath + @"\Nhibernate.Config.xml");

            cfg.AddAssembly("BO");
            //cfg.AddXmlFile(basePath + @"\Person.hbm.xml");
            //cfg.AddXmlFile(basePath + @"\Area.hbm.xml");
            //cfg.AddXmlFile(basePath + @"\Authority.hbm.xml");
            //cfg.AddXmlFile(basePath + @"\CheckLog.hbm.xml");
            //cfg.AddXmlFile(basePath + @"\AppUser.hbm.xml");

            ISessionFactory result = cfg.BuildSessionFactory();

            return result;
        }

        private static ISession _session=null;

        public static ISession session
        {
            get 
            {
                if (_session==null)
                {
                   _session = SessionFactory.Instance.OpenSession();
                   _session.FlushMode = FlushMode.Commit;
                }

                _session.Clear();
                return _session; 
            }
        }

        public static ISession GetNewSession()
        {
            return session;
        }

    }
}