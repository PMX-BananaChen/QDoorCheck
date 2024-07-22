using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace BO.DBAccess
{
   internal  class DB_CheckLog
    {
       public static void SaveLog(CheckLog log)
       {
           ISession session = SessionFactory.GetNewSession();
           session.Save(log);
           session.Flush();
       }
    }
}

