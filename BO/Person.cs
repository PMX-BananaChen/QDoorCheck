using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace BO
{
    public class Person
    {
        #region Properties
        
        private Guid _sid;

        public virtual Guid Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        private string _cardNo;

        public virtual string CardNo
        {
            get { return _cardNo; }
            set { _cardNo = value; }
        }

        private string _personName;

        public virtual string PersonName
        {
            get { return _personName; }
            set { _personName = value; }
        }




        private string _workNo;

        public virtual string WorkNo
        {
            get { return _workNo; }
            set { _workNo = value; }
        }

        private string _depart;

        public virtual string Depart
        {
            get { return string.IsNullOrEmpty(_depart)?string.Empty:_depart; }
            set { _depart = value; }
        }

        private string _job;

        public virtual string Job
        {
            get { return string.IsNullOrEmpty(_job)?string.Empty:_job; }
            set { _job = value; }
        }

        private bool _isActive=true;

        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private bool _isInner = true;

        public virtual bool IsInner
        {
            get { return _isInner; }
            set { _isInner = value; }
        }   

        private DateTime _addTime;

        public virtual DateTime AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }



        private string _cptNo;

        public virtual string cptNo
        {
            get { return _cptNo; }
            set { _cptNo = value; }
        }

        private byte[] _photoData;

        protected virtual byte[] PhotoData
        {
            get {
                if (_photoData==null)
                {
                    _photoData = new byte[] { };
                }
                return _photoData; }
            set { _photoData = value; }
        }


        private Image _photo;

        public virtual Image Photo
        {
            get 
            {
                if (_photo==null && PhotoData!=null &&PhotoData.Length>0)
                {
                    _photo= Image.FromStream(new MemoryStream(PhotoData));
                }


              
                return _photo; 
            }
            set 
            {
                if (value!=_photo)
	            {
                    _photo = value;
                    MemoryStream ms = new MemoryStream();
                    value.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                    PhotoData= ms.ToArray();

                    ms.Dispose();
                    GC.Collect();
            	}
            }
        }


        private IList<Authority> _authorities;

        public virtual IList<Authority> Authorities
        {
            get 
            {
                if (_authorities==null)
                {
                    _authorities = new List<Authority>();
                }
                return _authorities; 
            }
            set { _authorities = value; }
        }

        public virtual bool IsNew
        {
            get
            { return this.Sid == Guid.Empty; }
        }
        
        #endregion

        public Person()
        {
            // cause this property would be setted by nhibernate,so it should not be settled here.
            //this.Sid = Guid.NewGuid(); 
        }


        #region Static functions

        public static void SavePerson(Person person)
        {
            DBAccess.DB_Person.SavePerson(person);
        }

        public static bool IsCardExists(string cardNo)
        {
            return DBAccess.DB_Person.ExistsCardNo(cardNo);
        }

        //public static void SavePersonWithAuthorities(Person person)
        //{
        //    DBAccess.DB_Person.SavePersonWithAuthorities(person);
        //}

        public static List<Person> GetAllPersons()
        {
            return DBAccess.DB_Person.GetAllPersons();
        }

        public static IList<Person> GetPersons(string keyValue)
        {
            return DBAccess.DB_Person.GetPersonsByKeyValue(keyValue);
        }

        public static Person GetEmptyPerson()
        {
            return new Person();
        }

        public static List<string> GetExistsJobs()
        {
            List<string> result = new List<string>();
            result.AddRange(DBAccess.DB_Person.GetExistsJobs());
            result.Remove(null);
            return result;
        }

        public static List<string> GetExistsDeparts()
        {
            List<string> result = new List<string>();
            result.AddRange(DBAccess.DB_Person.GetExistsDeparts());
            result.Remove(null);
            return result;
        }

        public static Person GetPerson(string cardNo,bool? isActive)
        {
            return DBAccess.DB_Person.GetPerson(cardNo,isActive);
        }
        #endregion
    }
}
