using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace BO
{
    public class AreaConfiguration
    {

        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        } 
    

        private string _thisArea;

        public virtual string ThisArea
        {
            get { return _thisArea; }
            set { _thisArea = value; }
        }


        private string _IP;

        public virtual string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }


        private string _ComputerName;

        public virtual string ComputerName
        {
            get { return _ComputerName; }
            set { _ComputerName = value; }
        }


        private string _Keeper;

        public virtual string Keeper
        {
            get { return _Keeper; }
            set { _Keeper = value; }
        }


        private string _MacAdress;

        public virtual string MacAdress
        {
            get { return _MacAdress; }
            set { _MacAdress = value; }
        }


        public static AreaConfiguration GetAllIPByArea(string AreaID, string MacAdress, string ComputerName)
        {
            return DBAccess.DB_Area.GetAllIPByArea(AreaID, MacAdress, ComputerName);
        }

       
       
    }
}
