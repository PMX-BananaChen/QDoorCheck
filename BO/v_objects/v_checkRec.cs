using System;
using System.Collections.Generic;
using System.Text;

namespace BO.v_objects
{
    public class v_checkRec_1
    {
        private Guid _sid;

        public Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private string _personCard;

        public string PersonCard
        {
            get { return _personCard; }
            set { _personCard = value; }
        }

        private string _personName;

        public string PersonName
        {
            get { return _personName; }
            set { _personName = value; }
        }

        private string _personWorkNo;

        public string PersonWorkNo
        {
            get { return _personWorkNo; }
            set { _personWorkNo = value; }
        }

        private DateTime _time;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private string _memo;

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public v_checkRec_1(Guid sid,string userName,string area,string card,string personName,string workNo,DateTime time,string memo)
        {
            this.Sid = sid;
            this.UserName = userName;
            this.Area = area;
            this.PersonCard = card;
            this.PersonName = personName;
            this.PersonWorkNo = workNo;
            this.Time = time;
            this.Memo = memo;
        }
    }
}
