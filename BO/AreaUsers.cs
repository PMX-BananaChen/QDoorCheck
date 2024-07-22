using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class AreaUsers
    {
        #region Properties

        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private Guid _areaId;

        public virtual Guid AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }


        private Guid _userId;

        public virtual Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

    
        private string _roleId;

        public virtual string RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public virtual string PassWord
        {
            get { return Encrypt.DoDecrypt(this.PasswordData); }
            set { PasswordData = Encrypt.DoEncrypt(string.IsNullOrEmpty(value) ? string.Empty : value); }
        }

        private string _passwordData;

        public virtual string PasswordData
        {
            get { return _passwordData; }
            set { _passwordData = value; }
        }


        public static List<Sys_User> GetAllSysUser(List<AreaUsers> area)
        {
            return DBAccess.DB_Area.GetAllSysUser(area);
        }

        public static List<AreaUsers> GetAllAreaUsers(Area area,String RoleID)
        {
            return DBAccess.DB_Area.GetAllAreaUsers(area, RoleID);
        }

        public static void SaveAreaUsers(AreaUsers AreaUsers)
        {

            DBAccess.DB_Area.SaveOrUpdateAreaUsers(AreaUsers);

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
