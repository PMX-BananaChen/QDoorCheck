using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace BO.DBAccess
{
    internal class DB_Person
    {

//#if DEBUG
//        private static List<Person> _persons;

//        public static List<Person> Persons
//        {
//            get 
//            {
//                if (null==_persons)
//                {
//                    _persons = new List<Person>();

//                    Person person1 = new Person();
//                    person1.CardNo = "123456789";
//                    person1.WorkNo = "0001";
                    
//                    person1.PersonName = "張三";
//                    person1.Job = "工程師";
//                    person1.Depart = "RD";

//                    _persons.Add(person1);

//                    Person person2 = new Person();
//                    person2.CardNo = "987654321";
//                    person2.WorkNo = "0002";
//                    person2.PersonName = "李四";
//                    person2.Job = "初級工程師";
//                    person2.Depart = "技術服務部";

//                    _persons.Add(person2);

//                    Person person3 = new Person();
//                    person3.CardNo = "543216789";
//                    person3.WorkNo = "0003";
//                    person3.PersonName = "李小江";
//                    person3.Job = "高級工程師";
//                    person1.Depart = "生技部";

//                    _persons.Add(person3);
//                }
//                return _persons; 
//            }
//        }

//#endif
        public static bool ExistsPerson(Person person)
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Person person where person=:person");
            query.SetParameter("person", person);
            return (Int64)query.List()[0] > 0;
        }

        public static bool ExistsCardNo(string cardNo)
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Person person where person.CardNo=:cardNo");
            query.SetParameter("cardNo", cardNo);
            return (Int64)query.List()[0] > 0;
        }

        public static List<Person> GetAllPersons()
        {
            ISession session = SessionFactory.GetNewSession();

            ICriteria criteria = session.CreateCriteria(typeof(Person));

            List<Person> result = new List<Person>();

            result.AddRange(criteria.List<Person>());
            return result;
        }

        public static IList<string> GetExistsJobs()
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select distinct p.Job from Person p");
            return query.List<string>();
        }

        public static IList<string> GetExistsDeparts()
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select distinct p.Depart from Person p");
            return query.List<string>();
        }

        public static void SavePerson(Person person)
        {
            ISession session = SessionFactory.GetNewSession();
        
            ITransaction t= session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(person);
                foreach (Authority auth in person.Authorities)
                {
                    session.SaveOrUpdate(auth);
                }
                session.Flush();
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                throw;
            }                 
        }

        public static Person GetPerson(string cardNo,bool? isActive)
        {
            ISession session = SessionFactory.GetNewSession();

            ICriteria cri = session.CreateCriteria(typeof(BO.Person));
            cri.Add(new NHibernate.Expression.EqExpression("CardNo", cardNo));
            if (isActive!=null)
            {
                cri.Add(new NHibernate.Expression.EqExpression("IsActive", isActive.Value));
            }

            IList<Person> result = cri.List<Person>();
            //string strquery = string.Empty;
            //if (isActive == null)
            //{
            //    strquery = "from Person p where p.CardNo=:cardNo";
            //}
            //else
            //{
            //    strquery = "from Person p where p.CardNo=:cardNo and IsActive=:isActive";
            //}

            //IQuery query = session.CreateQuery(strquery);
            //query.SetParameter("cardNo", cardNo);
            //if (isActive!=null)
            //{
            //    query.SetParameter("isActive", isActive);
            //}

            //IList<Person> result = query.List<Person>();
            return result.Count > 0 ? result[0] : null;
        }

        public static IList<Person> GetPersonsByKeyValue(string keyValue)
        {
            ISession session = SessionFactory.GetNewSession();

            ICriteria cri = session.CreateCriteria(typeof(BO.Person));
            NHibernate.Expression.ICriterion forCardNo= new NHibernate.Expression.LikeExpression("CardNo", keyValue, NHibernate.Expression.MatchMode.Anywhere);
            NHibernate.Expression.ICriterion empNo = new NHibernate.Expression.LikeExpression("WorkNo", keyValue, NHibernate.Expression.MatchMode.Anywhere);
         
            NHibernate.Expression.ICriterion forName = new NHibernate.Expression.LikeExpression("PersonName", keyValue, NHibernate.Expression.MatchMode.Anywhere);

            //cri.Add(new NHibernate.Expression.OrExpression(forCardNo, forName));

            cri.Add(new NHibernate.Expression.Disjunction().Add(forCardNo).Add(forName).Add(empNo)); 

            return cri.List<Person>();
            
        }

        //public static void SavePersonWithAuthorities(Person person)
        //{ 
        // try
        //    {
        //        using (System.Transactions.TransactionScope t=new System.Transactions.TransactionScope())
        //        {
        //            SavePerson(person);
        //            foreach (Authority item in person.Authorities)
        //            {
        //                Authority.SaveAuthority(item);
        //            }
        //            t.Complete();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
          
        //}

//        public static Person GetPerson(Guid personId)
//        {
//#if DEBUG
//            return Persons.Find(new Predicate<Person>(delegate(Person item)
//            { return item.Sid == personId; }));
//#endif
//        }
    }
}
