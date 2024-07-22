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
    /// Summary description for Combobox
    /// </summary>
    public class Combobox : IHttpHandler
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

        [DataContract]
        public class ReturnDate
        {
            [DataMember]
            public string value { get; set; }
            [DataMember]
            public string text { get; set; }
            [DataMember]
            public string group { get; set; }

            public ReturnDate(string u,string p,string s)  
            {  
               value = u;  
               text = p;  
               group = s;  
            }  

        }

        public string QueryData(HttpContext context)
        {
            //資料庫分頁取得資料方法           

            DataSet ds = mydb.mydataset("exec proc_load_BU_Area ");
            
            List<ReturnDate> Users = new List<ReturnDate>();     

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Users.Add(new ReturnDate(dr["sid"].ToString(), dr["areaName"].ToString(), dr["BU"].ToString()));               
            }

            string json = ToJsJson(Users);
            return json;
           
        }

        public static string ToJsJson(object item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }  


    }   
   
}