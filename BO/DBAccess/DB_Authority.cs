using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace BO.DBAccess
{
    internal class DB_Authority
    {
        public static Authority GetAuthority(Area area, string cardNo,bool isActive)
        {
//#if DEBUG
//            //if (!DB_Area.Areas.Exists(new Predicate<Area>(delegate (Area item)
//            //{ return item.Sid == areaId; })))
//            //{
//            //    return null;
//            //}

//            Person thisPerson= DB_Person.Persons.Find(new Predicate<Person>(delegate (Person item)
//            { return item.CardNo == cardNo; }));
            
//            if (thisPerson==null)
//            {
//                return null;
//            }

//            Authority thisAuth = new Authority();

//            thisAuth.ThisArea = area;
//            thisAuth.ThisPerson = thisPerson;
//            thisAuth.EnableEnterIn = true;
//            thisAuth.EnablePhoto = false;
//            thisAuth.EnableMoveMaterial = true;

//            return thisAuth;
//#else
            ISession session=SessionFactory.GetNewSession();

            IQuery query = session.CreateQuery("from Authority auth where auth.ThisArea=:area and auth.ThisPerson.CardNo=:cardNo and auth.ThisPerson.IsActive=:isActive");
            query.SetParameter("area", area);
            query.SetParameter("cardNo", cardNo);
            query.SetParameter("isActive", isActive);

            IList<Authority> result = query.List<Authority>();
            return result.Count > 0 ? result[0] : null;
//#endif
        }

        public static bool ExistsAuthority(Authority auth)
        { 
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Authority auth where auth=:auth");
            query.SetParameter("auth",auth);
            return (Int64)query.List()[0] > 0;
        }

        public static bool ExistsAuthority(Area area, Person person)
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Authority auth where auth.ThisArea=:area and auth.ThisPerson=:person");
            query.SetParameter("area", area);
            query.SetParameter("person", person);

            return (Int64)query.List()[0] > 0;
        }

        public static void SaveAuthority(Authority auth)
        {
            ISession session = SessionFactory.GetNewSession();
            session.SaveOrUpdate(auth);
            session.Flush();
        }
    }
}
