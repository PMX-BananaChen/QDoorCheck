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
    public class Information : IHttpHandler
    {
        database mydb = new database();

        public void ProcessRequest(HttpContext context)
        {
           

            Int32 rows = Convert.ToInt32(context.Request["rows"]);
            if (rows <= 50)
            {
                context.Response.ContentType = "application/json";
                string json = QueryData(context);
                context.Response.Write(json);               
            }
            else
            {
                context.Response.ContentType = "text/plain";
                SaveDoc(context, 1, "report.xls", context.Response);

            }
              context.Response.End();  
       
       
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void SaveDoc(HttpContext context, int eFlag, string fileName, HttpResponse resp)
        {

            Int32 page = Convert.ToInt32(context.Request["page"]);
            Int32 rows = Convert.ToInt32(context.Request["rows"]);
            string Areaid = context.Request["AreaName"]; 

            DataTable dataTable = mydb.mydataset("exec proc_load_PlantAuthority " + page + "," + rows + ",'" + Areaid + "' ").Tables[0];

            resp.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            resp.ContentType = "application/ms-excel";
            resp.Charset = "Big5";
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("Big5");
            resp.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5");
            string colHeaders = "", ls_item = "";
            int i = 0;
            //定义表对象和行对像，同时用DataSet对其值进行初始化 
            DataRow[] myRow = dataTable.Select("");
            if (eFlag == 1)
            {
                //取得数据表各列标题，各标题之间以/t分割，最后一个列标题后加回车符 
                for (i = 1; i < dataTable.Columns.Count; i++)
                {
                    if (i == dataTable.Columns.Count - 1)
                    {
                        colHeaders += dataTable.Columns[i].Caption.ToString() + "\n";
                    }
                    else
                    {
                        colHeaders += dataTable.Columns[i].Caption.ToString() + "\t";
                    }
                }
                //向HTTP输出流中写入取得的数据信息 
                resp.Write(colHeaders);
                //逐行处理数据 
                foreach (DataRow row in myRow)
                {
                    //在当前行中，逐列获得数据，数据之间以/t分割，结束时加回车符/n 
                    for (i = 1; i < dataTable.Columns.Count; i++)
                    {

                        if (i == dataTable.Columns.Count - 1)
                        {
                            ls_item += row[i].ToString() + "\n";
                        }
                        else
                        {
                            ls_item += row[i].ToString() + "\t";
                        }
                    }
                    //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                    resp.Write(ls_item);
                    ls_item = "";
                }
            }
            else if (eFlag == 2)
            {
                //从DataSet中直接导出XML数据并且写到HTTP输出流中 
                resp.Write(dataTable.DataSet.GetXml());
            }
            //写缓冲区中的数据到HTTP头文档中 
            resp.Flush();
            resp.End();
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


            Int32 page = Convert.ToInt32(context.Request["page"]);
            Int32 rows = Convert.ToInt32(context.Request["rows"]);
            string Areaid = context.Request["AreaName"];   
           
            List<IDE> li = new List<IDE>();

            DataSet ds_Local = mydb.mydataset("exec proc_load_PlantAuthority " + page + "," + rows + ",'" + Areaid + "' ");

            foreach (DataRow dr in ds_Local.Tables[0].Rows)
            {
                li.Add(new IDE(){
               
                    BU = dr["BU"].ToString(),
                    areaName = dr["areaName"].ToString(),
                    cardNo = dr["cardNo"].ToString(),
                    personName = dr["personName"].ToString(),
                    workNo = dr["workNo"].ToString(),
                    enableEnterIn = showVendorType(dr["enableEnterIn"].ToString()),
                    enableMoveMaterial =showVendorType(dr["enableMoveMaterial"].ToString()),
                    enableMobile = showVendorType(dr["enableMobile"].ToString()),
                    enablePhoto = showVendorType(dr["enablePhoto"].ToString()),
                    enableLaptop = showVendorType(dr["enableLaptop"].ToString()),
                    enableU = showVendorType(dr["enableU"].ToString()),
                    isActive = showVendorType(dr["isActive"].ToString())
                   
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
             [DataMember(Order = 0)]
            public string total { get; set; }
             [DataMember(Order = 1)]
             public List<IDE> rows { get; set; }
        }

        
        public class IDE
        {           
      
            public string BU { get; set; }

            public string areaName { get; set; }

            public string cardNo { get; set; }

            public string personName { get; set; }

            public string workNo { get; set; }

            public string enableEnterIn { get; set; }

            public string enableMoveMaterial { get; set; }

            public string enableMobile { get; set; }

            public string enablePhoto { get; set; }

            public string enableLaptop { get; set; }

            public string enableU { get; set; }

            public string isActive { get; set; }
          
        }


        public string showVendorType(string state)
        {

            string strState = null;

            switch (state)
            {
                case "True":
                    strState = "./images/d.gif";
                    break;

                case "False":
                    strState = "./images/c.gif";
                    break;

                default:
                    strState = "./images/c.gif";

                    break;
            }

            return strState;

        }


    }


}