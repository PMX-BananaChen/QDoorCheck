using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Myclass;
using System.Configuration;
using System.IO;

namespace IDE
{
    public partial class HomePage : System.Web.UI.Page
    {
        database mydb = new database();
        CSVHelper CSVs = new CSVHelper();
        FTP FTPs = new FTP();
        

        protected void Page_Load(object sender, EventArgs e)
        {

          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //配置每100條記錄生成一個CSV (Webconfig中配置此數字)

            DataTable DT = mydb.mydataset("select * from dbo.Source ").Tables[0];

            Int32 PerCSVCount = Convert.ToInt32(ConfigurationManager.AppSettings["PerCSVCount"].ToString());
            Int32 RowCount = DT.Rows.Count;
            Int32 CSVCount = (RowCount + PerCSVCount - 1) / PerCSVCount;

            //循環導出CSV

            for (int i = 0; i < CSVCount; i++)
            { 
                DataTable DT_CSV = mydb.mydataset("exec Sp_Conn_Sort 'source','*','Nid'," + PerCSVCount + "," +(i +1)+ ",0,0,'' ").Tables[0];


                string strFile = "";
                string path = "";
                strFile = "Test_" + (i + 1).ToString()+".csv";               
                path = HttpContext.Current.Server.MapPath("~/CSV/" + strFile);
                CSVs.ExportToSvc(DT_CSV, path);

                //上傳文件到FTP目錄              
                FTP FTPs = new FTP();
                FTPs.UploadToFTP(path, "FTP://10.40.1.186:125/FTPTest", "PCN\\Sherry.Wei", "750202Px");              


            }
        }
    }
}