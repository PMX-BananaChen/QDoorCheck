using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Sys_User
    {
        #region Properties

        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _workNo;

        public virtual string WorkNo
        {
            get { return _workNo; }
            set { _workNo = value; }
        }

        private string _userName;

        public virtual string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _dept;

        public virtual string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        private string _job;

        public virtual string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        private bool _enable=true;

        public virtual bool enable
        {
            get { return _enable; }
            set { _enable = value; }
        }


        public static void SaveSysUser(Sys_User SysUser)
        {
            DBAccess.DB_Area.SaveOrUpdateSysUser(SysUser);

        }

        public static Sys_User GetAllByUserName(String UserName)
        {
           return  DBAccess.DB_Area.GetAllByUserName(UserName);

        }   


        #endregion

        #region Static functions

        public static AppUser GetAdminUser()
        {
            AppUser appUser= DBAccess.DB_AppUser.GetAdminUser();
            if (null==appUser)
            {
                throw new Exception("類資料庫找不到Admin用戶的訊息!");
            }
            return appUser;
        }

        public static AppUser GetGeneralUser()
        {
            AppUser appUser = DBAccess.DB_AppUser.GetGeneralUser();
            if (null==appUser)
            {
                throw new Exception("在資料庫中找不到 General 用戶的訊息!");
            }

            return appUser;
        }

        public static void SaveAppUser(AppUser appUser)
        {
            DBAccess.DB_AppUser.SaveAppuser(appUser);
        }

        #endregion
    }
}
