using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class CheckLog
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


        private Area _thisArea;

        public virtual Area ThisArea
        {
            get { return _thisArea; }
            set { _thisArea = value; }
        }

        private Person _thisPerson;

        public virtual Person ThisPerson
        {
            get { return _thisPerson; }
            set { _thisPerson = value; }
        }

        private string _cardNo;

        public virtual string CardNo
        {
            get { return _cardNo; }
            set { _cardNo = value; }
        }


        private string _logContent;

        public virtual string LogContent
        {
            get { return _logContent; }
            set { _logContent = value; }
        }

        private DateTime _logTime;

        public virtual DateTime LogTime
        {
            get { return _logTime; }
            set { _logTime = value; }
        }

        #endregion


        #region static functions

        public static void Log(Person person,Area area, Authority auth,string cardNo, string userName)
        {
            CheckLog log = new CheckLog();
            log.UserName = userName;
            log.ThisArea = area;
            log.ThisPerson = person;
            log.CardNo = cardNo;
            if (auth == null)
            {
                log.LogContent = string.Format("allow enter-in:{0};allow photo:{1};allow move material:{2};allow mobile:{3};allow laptop{4};allow U:{5}", false, false, false,false,false,false);

            }
            else
            {
                log.LogContent = string.Format("allow enter-in:{0};allow photo:{1};allow move material:{2};allow mobile:{3};allow laptop{4};allow U:{5}", auth.EnableEnterIn, auth.EnablePhoto, auth.EnableMoveMaterial, auth.EnableMobile,auth.enableLaptop, auth.enableU);
            }
            log.LogTime = DateTime.Now;

            DBAccess.DB_CheckLog.SaveLog(log);
        }

        #endregion
    }
}
