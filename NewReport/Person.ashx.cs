using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data;
using Myclass;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace IDE
{
    /// <summary>
    /// Summary description for Pagation
    /// </summary>
    public class Person : IHttpHandler
    {
        database mydb = new database();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string json = QueryData(context);
            context.Response.Write(json);
            context.Response.End();  
       
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string QueryData(HttpContext context)
        {
            //資料庫分頁取得資料方法
            //string page = context.Request["page"];
            //string rows = context.Request["rows"];
            //string Packinglist=context.Request["PackinglistNo"];
            //string PO=context.Request["PO"];
            //string PalletID=context.Request["PalletID"];
            //string CartonID=context.Request["CartonID"];
            //string SN=context.Request["SN"];
            //string SKU=context.Request["SKU"];
            //string MFGFrom=context.Request["MFGFrom"];
            //string MFGEnd=context.Request["MFGEnd"];
            //Int32 User_id=Convert.ToInt32( context.Request["Userid"]);            
            //string Factory = context.Request["Factory"];

            string BU = context.Request["BU"].ToString();

            List<Persons> li = new List<Persons>();

            DataSet ds_Local = mydb.mydataset("exec proc_load_Person '" + BU + "' ");
            if (ds_Local.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_Local.Tables[0].Rows)
                {
                    li.Add(new Persons()
                    {
                        sid = dr["sid"].ToString(),
                        CardNo = dr["CardNo"].ToString(),
                        PersonName = dr["PersonName"].ToString(),
                        WorkNo = dr["WorkNo"].ToString(),
                        depart = dr["depart"].ToString(),
                        job = dr["job"].ToString(),
                        isActive = dr["isActive"].ToString()
                    });
                }

                ReturnDate rd = new ReturnDate();
                rd.total = ds_Local.Tables[1].Rows[0][0].ToString();
                rd.rows = li;
                DataContractJsonSerializer json = new DataContractJsonSerializer(rd.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    json.WriteObject(ms, rd);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                    return sb.ToString();
                } 

            }
            else
            {
                return null;

            }
            
        }

        [DataContract]
        public class ReturnDate
        {
             [DataMember (Order=0)]
            public string total { get; set; }
             [DataMember(Order=1)]
             public List<Persons> rows { get; set; }
        }

        
        public class Persons
        {

            public string sid { get; set; }

            public string CardNo { get; set; }

            public string PersonName { get; set; }
            
            public string WorkNo { get; set; }  
           
            public string depart { get; set; }
           
            public string job { get; set; }     
           
            public string isActive { get; set; }
           
           
        }  

    }
}