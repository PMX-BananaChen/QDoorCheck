using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class AppUser
    {
        #region Properties

        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _userName;

        public virtual string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public virtual string Password
        {
            get { return Encrypt.DoDecrypt(this.PasswordData); }
            set { PasswordData=Encrypt.DoEncrypt(value); }
        }

        private string _passwordData;

        public virtual string PasswordData
        {
            get { return _passwordData; }
            set { _passwordData = value; }
        }


        private string _description;

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        #endregion

        #region Static functions

        public static AppUser GetAdminUser()
        {
            AppUser appUser= DBAccess.DB_AppUser.GetAdminUser();
            if (null==appUser)
            {
                throw new Exception("����Ʈw�䤣��Admin�Τ᪺�T��!");
            }
            return appUser;
        }

        public static AppUser GetGeneralUser()
        {
            AppUser appUser = DBAccess.DB_AppUser.GetGeneralUser();
            if (null==appUser)
            {
                throw new Exception("�b��Ʈw���䤣�� General �Τ᪺�T��!");
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
