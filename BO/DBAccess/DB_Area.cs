using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using NHibernate;
using NHibernate.Expression;


namespace BO.DBAccess
{
    public class DB_Area
    {
        

        #region Static functions

        public static List<Area> GetAllAreas()
        {

            ISession session=SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(Area));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("enable", true));
            criteria.AddOrder(new Order("AreaName", false));


            List<Area> result = new List<Area>();

            //result.AddRange(criteria.AddOrder(new Order("BU", false)).List<Area>());

            result.AddRange(criteria.List<Area>());

            return result;

        }


        public static List<Sys_User> GetAllSysUser(List<AreaUsers> AreaUserlist)
        {           

            List<Sys_User> result = new List<Sys_User>();      

            foreach (AreaUsers item in AreaUserlist)
            {

                ISession session = SessionFactory.GetNewSession();
                ICriteria criteria = session.CreateCriteria(typeof(Sys_User));

                //Nhibernate筛选条件语法
                criteria.Add(Expression.Eq("Sid", item.UserId));
                criteria.Add(Expression.Eq("enable", true));
                result.AddRange(criteria.List<Sys_User>());

            }

            return result;

        }


        public static List<AreaUsers> GetAllAreaUsers(Area area,String RoleID)
        {

            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(AreaUsers));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("AreaId", area.Sid));
            criteria.Add(Expression.Eq("RoleId", RoleID));
            // criteria.AddOrder(new Order("AreaName", false));

            List<AreaUsers> AreaUserlist = new List<AreaUsers>();
           
            AreaUserlist.AddRange(criteria.List<AreaUsers>());

            return AreaUserlist;

        }        



        public static AreaUsers CheckPassWord_Admin(Area area, Sys_User sysUser, String PassWord)
        {

            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(AreaUsers));

            //Nhibernate筛选条件语法           
            criteria.Add(Expression.Eq("UserId", sysUser.Sid));
            criteria.Add(Expression.Eq("PasswordData", Encrypt.DoEncrypt(PassWord).ToString()));
            // criteria.AddOrder(new Order("AreaName", false));

            List<AreaUsers> AreaUserlist = new List<AreaUsers>();

            AreaUserlist.AddRange(criteria.List<AreaUsers>());

            return AreaUserlist.Count > 0 ? AreaUserlist[0] : null;

        }


        public static AreaUsers CheckPassWord(Area area, Sys_User sysUser, String PassWord)
        {

            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(AreaUsers));

            //Nhibernate筛选条件语法           
            criteria.Add(Expression.Eq("AreaId", area.Sid));          
            criteria.Add(Expression.Eq("UserId", sysUser.Sid));
            criteria.Add(Expression.Eq("PasswordData", Encrypt.DoEncrypt(PassWord).ToString()));
            // criteria.AddOrder(new Order("AreaName", false));

            List<AreaUsers> AreaUserlist = new List<AreaUsers>();

            AreaUserlist.AddRange(criteria.List<AreaUsers>());

            return AreaUserlist.Count > 0 ? AreaUserlist[0] : null;

        }


        public static Area GetAllAreaByName(string AreaName)
        {
            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(Area));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("AreaName", AreaName));

            List<Area> result = new List<Area>();          

            result.AddRange(criteria.List<Area>());

            return result.Count > 0 ? result[0] : null;

        }


        public static AreaConfiguration GetAllIPByArea(string AreaID, string MacAdress, string ComputerName)
        {
            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(AreaConfiguration));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("ThisArea", AreaID));
            criteria.Add(Expression.Eq("MacAdress", MacAdress));
            criteria.Add(Expression.Eq("ComputerName", ComputerName));

            List<AreaConfiguration> result = new List<AreaConfiguration>();

            result.AddRange(criteria.List<AreaConfiguration>());          

           return result.Count > 0 ? result[0] : null;          
      

        }

        public static Sys_User GetAllByUserName(string UserName)
        {
            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(Sys_User));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("WorkNo", UserName));

            List<Sys_User> result = new List<Sys_User>();

            result.AddRange(criteria.List<Sys_User>());         

            return result.Count > 0 ? result[0] : null;

        }

        //public static void InsertArea(Area newArea)
        //{
        //    //string sql = "Insert into [Area](sid,areaName,description) values (@sid,@areaName,@desc)";

        //    ISession session = SessionFactory.GetNewSession();
        //    session.Save(newArea);
        //    session.Flush();
        //}

        //public static void UpdateArea(Area area)
        //{
        //    ISession session = SessionFactory.GetNewSession();
        //    session.Update(area);
        //    session.Flush();
        //}

        public static bool ExistsAreaByName(string areaName)
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Area area where area.AreaName=:areaName");
            query.SetParameter("areaName", areaName);
            return (Int64)query.List()[0] > 0;
        }

        public static bool ExistsArea(Area area)
        { 
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select count(*) from Area  area where area=:area");
            query.SetParameter("area", area);
            return (Int64)query.List()[0] > 0;
        }

        public static List<String> GetAllBUs()
        {
            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery("select distinct P.BU from Area P order by P.BU desc ");
            List<string> result = new List<string>();
            result.AddRange(query.List<String>());
            return result;

        }      
 

         public static HR_Employee GetAllByEmpNO(string UserName)
        {
            ISession session = SessionFactory.GetNewSession();
            ICriteria criteria = session.CreateCriteria(typeof(HR_Employee));

            //Nhibernate筛选条件语法
            criteria.Add(Expression.Eq("Emp_No", UserName));

            List<HR_Employee> result = new List<HR_Employee>();

            result.AddRange(criteria.List<HR_Employee>());         

            return result.Count > 0 ? result[0] : null;

        }

                      
        public static void SaveOrUpdateArea(Area area)
        {
            if (area==null)
            {
                throw new ArgumentNullException("Area");
            }

            ISession session = SessionFactory.GetNewSession();

            session.SaveOrUpdate(area);
            session.Flush();
            //if (ExistsArea(area))
            //{
            //    UpdateArea(area);
            //}
            //else
            //{
            //    InsertArea(area);
            //}
        }



        public static void SaveOrUpdateSysUser(Sys_User SysUser)
        {
            if (SysUser == null)
            {
                throw new ArgumentNullException("SysUser");
            }

            ISession session = SessionFactory.GetNewSession();

            session.SaveOrUpdate(SysUser);
            session.Flush();
            //if (ExistsArea(area))
            //{
            //    UpdateArea(area);
            //}
            //else
            //{
            //    InsertArea(area);
            //}
        }

        public static void SaveOrUpdateAreaUsers(AreaUsers AreaUsers)
        {
            if (AreaUsers == null)
            {
                throw new ArgumentNullException("SysUser");
            }

            ISession session = SessionFactory.GetNewSession();

            session.SaveOrUpdate(AreaUsers);
            session.Flush();
            //if (ExistsArea(area))
            //{
            //    UpdateArea(area);
            //}
            //else
            //{
            //    InsertArea(area);
            //}
        }

        #endregion

    }
}
