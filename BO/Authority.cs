using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class Authority
    {
        #region Properties

        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        //private Guid _personId;

        //public Guid PersonId
        //{
        //    get { return _personId; }
        //    set { _personId = value; }
        //}

        //private Person _thisPerson;

        //public Person ThisPerson
        //{
        //    get 
        //    {
        //        if (Guid.Empty==PersonId)
        //        {
        //            return null;
        //        }
        //        if (_thisPerson==null || _thisPerson.Sid!=PersonId)
        //        {
        //            _thisPerson = DBAccess.DB_Person.GetPerson(PersonId);
        //        }
        //        return _thisPerson; 
        //    }
        //    set
        //    {
        //        PersonId = (null == value ? Guid.Empty : value.Sid);
        //        _thisPerson = value;
        //    }
        //}

        private Person _thisPerson;

        public virtual Person ThisPerson
        {
            get { return _thisPerson; }
            set { _thisPerson = value; }
        }


        public virtual string PersonName
        {
            get
            { return null == ThisPerson ? string.Empty : ThisPerson.PersonName; }
        }
        
        //private Guid _areaId;

        //public Guid AreaId
        //{
        //    get { return _areaId; }
        //    set { _areaId = value; }
        //}

        //private Area _thisArea;

        //public Area ThisArea
        //{
        //    get 
        //    {
        //        if (Guid.Empty==AreaId)
        //        {
        //            return null;
        //        }
        //        if (_thisArea==null || _thisArea.Sid!=AreaId)
        //        {
        //            _thisArea = DBAccess.DB_Area.GetArea(AreaId);
        //        }
        //        return _thisArea; 
        //    }
        //    set 
        //    {
        //        AreaId = (null == value ? Guid.Empty : value.Sid);
        //        _thisArea = value; 
        //    }
        //}

        private Area _thisArea;

        public virtual Area ThisArea
        {
            get { return _thisArea; }
            set { _thisArea = value; }
        }       

        public virtual string AreaName
        {
            get
            { return null == ThisArea ? string.Empty : ThisArea.AreaName; }
        }
        

        private bool _enableEnterIn;

        public virtual bool EnableEnterIn
        {
            get { return _enableEnterIn; }
            set { _enableEnterIn = value; }
        }

        private bool _enablePhoto;

        public virtual bool EnablePhoto
        {
            get { return _enablePhoto; }
            set { _enablePhoto = value; }
        }

        private bool _enableMoveMaterial;

        public virtual bool EnableMoveMaterial
        {
            get { return _enableMoveMaterial; }
            set { _enableMoveMaterial = value; }
        }

        private bool _enableMobile;

        public virtual bool EnableMobile
        {
            get { return _enableMobile; }
            set { _enableMobile = value; }
        }


        private bool _enableLaptop;

        public virtual bool enableLaptop
        {
            get { return _enableLaptop; }
            set { _enableLaptop = value; }
        }


        private bool _enableU;

        public virtual bool enableU
        {
            get { return _enableU; }
            set { _enableU = value; }
        }


        private string _description;

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

     

        #endregion

        public Authority()
        {
            // cause this property would be setted by nhibernate,so it should not be settled here.
            //this.Sid = Guid.NewGuid();
        }

        #region static functions

        public static Authority GetAuthority(Area area, string cardNo,bool isActive)
        {
            return DBAccess.DB_Authority.GetAuthority(area, cardNo,isActive);
        }

        public static void SaveAuthority(Authority auth)
        { DBAccess.DB_Authority.SaveAuthority(auth); }

        public static Authority GetEmptyAuthority()
        { return new Authority(); }

        public static bool ExistsAuthority(Area area, Person peron)
        {
            return DBAccess.DB_Authority.ExistsAuthority(area, peron);
        }

        #endregion
    }
}
