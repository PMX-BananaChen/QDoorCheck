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
    public class Delete : IHttpHandler
    {
        database mydb = new database();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";       
          
            string SN = context.Request["SN"];       
            string User_id = context.Request["User_id"];

            mydb.con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString();
            mydb.exec_sql("exec proc_delete_BySN '" + SN + "','" + User_id + "'");

            context.Response.Write('0');
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
            string page = context.Request["page"];
            string rows = context.Request["rows"];
            string Packinglist=context.Request["PackinglistNo"];
            string PO=context.Request["PO"];
            string PalletID=context.Request["PalletID"];
            string CartonID=context.Request["CartonID"];
            string SN=context.Request["SN"];
            string SKU=context.Request["SKU"];
            string MFGFrom=context.Request["MFGFrom"];
            string MFGEnd=context.Request["MFGEnd"];
            Int32 User_id=Convert.ToInt32( context.Request["Userid"]);

            List<IDE> li = new List<IDE>();            

            mydb.con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE"].ToString(); 
 
            DataSet ds = mydb.mydataset("exec P_Report_Ship_Belkin '" + PO + "','" + SKU + "','','" + Packinglist + "','" + PalletID + "','" + CartonID + "','" + SN + "','" + MFGFrom + "','" + MFGEnd + "',10000, 1 " );
            

            mydb.con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString(); 
 
            //刪除此用戶之前的查詢數據
            mydb.exec_sql("exec proc_delete_byUserid " + User_id);

            //將新的查詢結果插入到數據庫

            ImportOutlooExpByOleDB(ds.Tables[0], "Source");

            DataSet ds_Local = mydb.mydataset("exec proc_FTP_Source " + int.Parse(page) + "," + int.Parse(rows) + ",'','','" + User_id + "'");

            foreach (DataRow dr in ds_Local.Tables[0].Rows)
            {
                li.Add(new IDE(){
                   // source = dr["source"].ToString(),
                    Sku = dr["Sku"].ToString(),
                    sn = dr["sn"].ToString(),
                    cartonID = dr["cartonID"].ToString(),
                    ManufactureDate = dr["ManufactureDate"].ToString(),
                    CaseQty = dr["CaseQty"].ToString(),
                   // Supplier = dr["Supplier"].ToString(),
                    PO = dr["PO"].ToString(),
                   // FG = dr["FG"].ToString(),
                    PalletID = dr["PalletID"].ToString()
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

        [DataContract]
        public class ReturnDate
        {
             [DataMember]
            public string total { get; set; }
             [DataMember]
             public List<IDE> rows { get; set; }
        }

        
        public class IDE
        {
           
           // public string source { get; set; }
            
            public string Sku { get; set; }
            
            public string sn { get; set; }
           
            public string cartonID { get; set; }
           
            public string ManufactureDate { get; set; }
           
            public string CaseQty { get; set; }
          
           // public string Supplier { get; set; }
           
            public string PO { get; set; }
           
           // public string FG { get; set; }
            
            public string PalletID { get; set; }
        }


        public void ImportOutlooExpByOleDB(DataTable DT, string TableName)
        {          

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString();
            InsertToSqlService(connectionString, TableName, DT);

        }

        /// <summary>
        /// 批量插入的方法
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="tableName">要插入数据的表的名称</param>
        /// <param name="dt">数据源TataTable</param>
        public void InsertToSqlService(string connString, string tableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 2000;
                        bulkCopy.BulkCopyTimeout = 30;
                        bulkCopy.DestinationTableName = tableName;

                        try
                        {
                            foreach (DataColumn col in dt.Columns)
                            {
                                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                            }
                            bulkCopy.WriteToServer(dt);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }

        }



    }
}