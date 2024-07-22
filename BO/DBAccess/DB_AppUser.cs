using System;
using System.Collections.Generic;
using System.Text;
using Utility.Common;
using NHibernate;

namespace BO.DBAccess
{
    internal class DB_AppUser
    {
        public static AppUser GetAdminUser()
        {
            string adminUserName = "Admin";

            return GetUser(adminUserName);
        }

        public static AppUser GetGeneralUser()
        {
            string generalUserName = "General";

            return GetUser(generalUserName);
        }

        private static AppUser GetUser(string userName)
        { 
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("from AppUser appuser where appuser.UserName=:userName");
            query.SetParameter("userName", userName);

            IList<AppUser> result = query.List<AppUser>();
            return result.Count > 0 ? result[0] : null;
        }

        public static void SaveAppuser(AppUser appUser)
        {
            ISession session = SessionFactory.GetNewSession();
            session.SaveOrUpdate(appUser);
            session.Flush();
        }

      

        
        
    }
}
