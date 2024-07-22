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
    public partial class FTPList : System.Web.UI.Page
    {
        database mydb = new database();
        string cururl = "ResultPage.aspx?";//当前页面链接
        public int curpage = 0;//初始页
        public int pagesize = 10; //设置每页显示多少条记录

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {

                if (Request.Params["page"] == null)
                    curpage = 1;
                else
                {
                    string temp = Request.Params["page"].ToString();
                    curpage = Convert.ToInt32(temp);
                }

                string Datefrom = this.Request.QueryString["Datefrom"].ToString();
                string DateTo = this.Request.QueryString["DateTo"].ToString();

                mydb.con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString();
                DataTable DT_Files = mydb.mydataset("exec proc_FTP_Files '" + Datefrom + "','" + DateTo + "' ").Tables[0];
                string cururl = "FTPList.aspx?Datefrom=" + Datefrom + "&DateTo=" + DateTo;//当前页面链接
                Pages1.showthanklist(DT_Files, Repeater1, curpage, cururl, "../", 15 );                
               
            }         

        }      


    }
}