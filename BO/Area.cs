using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Area
    {
        #region Properties

        private Guid _sid;

        public Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _areaName;

        public string AreaName
        {
            get { return _areaName; }
            set { _areaName = value; }
        }

        private string _BU;

        public string BU
        {
            get { return _BU; }
            set { _BU = value; }
        }   
      

        private string _desc;

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        private bool _enable=true;

        public bool enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        private string _vision = "V1.0";

        public string Vision
        {
            get { return _vision; }
            set { _vision = value; }
        }

        
        #endregion

        public Area()
        {
            // cause this property would be setted by nhibernate,so it should not be settled here.
            //this.Sid = Guid.NewGuid();
        }


        // override object.Equals
        public override bool Equals(object obj)
        {

            //       
            // See the full list of guidelines at
            //   http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconequals.asp    
            // and also the guidance for operator== at
            //   http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconimplementingequalsoperator.asp
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here.
            return this.Sid == (obj as Area).Sid;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        
        public override string ToString()
        {
            return this.AreaName;
        }     


        #region static functions

        public static List<Area> GetAllAreas()
        { 
            return DBAccess.DB_Area.GetAllAreas();
        }

        public static Area GetAllAreaByName(string AreaName)
        {
            return DBAccess.DB_Area.GetAllAreaByName(AreaName);
        }
       

        public static List<String> GetAllBUs()
        {
            return DBAccess.DB_Area.GetAllBUs();
        }

        //public static void InsertArea(Area area)
        //{DBAccess.DB_Area.InsertArea(area);}

        //public static void UpdateArea(Area area)
        //{DBAccess.DB_Area.UpdateArea(area);}

        public static void SaveArea(Area area)
        { DBAccess.DB_Area.SaveOrUpdateArea(area); }

        #endregion
    }
}
