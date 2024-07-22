using System;
using System.Collections.Generic;
using System.Text;

using BO.v_objects;
using NHibernate;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;


namespace BO.DBAccess
{
    public class DB_Search
    {
        /// <summary>
        /// 查詢：使用nhibernate的HQL
        /// </summary>
        /// <param name="area"></param>
        /// <param name="keyvalue"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<v_checkRec> Search1(string area, string keyvalue,DateTime from,DateTime to)
        {
            //List<v_checkRec> result = new List<v_checkRec>();

            //result.Add(new v_checkRec(Guid.NewGuid(), "UserName1", "Area1", "card1", "personName1", "workNo1", DateTime.Now, "memo1"));
            //result.Add(new v_checkRec(Guid.NewGuid(), "UserName2", "Area2", "card2", "personName2", "workNo2", DateTime.Now, "memo2"));
            //result.Add(new v_checkRec(Guid.NewGuid(), "UserName3", "Area3", "card3", "personName3", "workNo3", DateTime.Now, "memo3"));
            //result.Add(new v_checkRec(Guid.NewGuid(), "UserName4", "Area4", "card4", "personName4", "workNo4", DateTime.Now, "memo4"));

            //return result;

            string hql = "select log.Sid,log.UserName,log.ThisArea.AreaName,log.ThisPerson.CardNo,log.ThisPerson.PersonName,log.ThisPerson.WorkNo,log.LogTime,log.LogContent " +
                        "from CheckLog log " +
                        "where log.LogTime between :from and :to ";
            
            Guid areaId=Guid.Empty;
            if (!string.IsNullOrEmpty(area))
            {
                areaId = new Guid(area);
                hql += "and log.ThisArea.Sid=:areaId ";
            }

            if (!string.IsNullOrEmpty(keyvalue))
            {
                hql += "and (log.ThisPerson.CardNo=:keyvalue or log.ThisPerson.PersonName=:keyvalue or log.ThisPerson.WorkNo=:keyvalue)";
            }

            ISession session = SessionFactory.GetNewSession();
            IQuery query = session.CreateQuery(hql);

            query.SetParameter("from", from);
            query.SetParameter("to", to);

            if (Guid.Empty!=areaId)
            {
                query.SetGuid("areaId", areaId);
            }

            if (!string.IsNullOrEmpty(keyvalue))
            {
                query.SetParameter("keyvalue", keyvalue);
            }


            IList objs= query.List();
            List<v_checkRec> result = new List<v_checkRec>();

            foreach (object obj in objs)
            {
                object[] row = obj as object[];
                result.Add(new v_checkRec(new Guid(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),row[5]==null?string.Empty: row[5].ToString(), (DateTime)row[6], row[7].ToString()));
            }

            result.Sort(new Comparison<v_checkRec>(delegate(v_checkRec item1, v_checkRec item2)
            { return item1.Time.CompareTo(item2.Time); }));

            return result;


        }

        /// <summary>
        /// 查詢：使用Entlib的SQL
        /// </summary>
        /// <param name="area"></param>
        /// <param name="keyvalue"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<v_checkRec> Search(string area, string keyvalue, DateTime from, DateTime to)
        {

            StringBuilder sb = new StringBuilder("select [log].Sid,[log].UserName,a.AreaName,p.CardNo,p.PersonName,p.WorkNo,[log].LogTime,[log].logContent "+
                                                "from checkLog [log],area a,Person p "+
                                                "where [log].areaId=a.Sid and [log].personId=p.Sid "+
                                                "and logTime between @from and @to ");

            Guid areaId = Guid.Empty;
            if (!string.IsNullOrEmpty(area))
            {
                areaId = new Guid(area);
                sb.Append(" and a.Sid=@areaId ");
            }
            
            if (!string.IsNullOrEmpty(keyvalue))
            {
                sb.AppendFormat(" and (p.CardNo like '%{0}%' or p.PersonName like '%{0}%' or p.WorkNo like '%{0}%') ",keyvalue);
            }

            sb.Append(" order by LogTime ");

            Database db = DatabaseFactory.CreateDatabase();          
            DbCommand cmd= db.GetSqlStringCommand(sb.ToString());
            
            db.AddInParameter(cmd, "@from",DbType.DateTime,from);
            db.AddInParameter(cmd, "@to",DbType.DateTime, to);
            if (Guid.Empty!=areaId)
            {
                db.AddInParameter(cmd, "@areaId",DbType.Guid, areaId);
            }

            List<v_checkRec> result = new List<v_checkRec>();
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                result.Add(new v_checkRec(new Guid(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), 
                                        reader[3].ToString(), reader[4].ToString(), reader[5] == null ? string.Empty : reader[5].ToString(), 
                                        (DateTime)reader[6], reader[7].ToString()));
            }
            
            reader.Close();
            reader.Dispose();
            //result.Sort(new Comparison<v_checkRec>(delegate(v_checkRec item1, v_checkRec item2)
            //{ return item1.Time.CompareTo(item2.Time); }));

            return result;


        }
    }
}
