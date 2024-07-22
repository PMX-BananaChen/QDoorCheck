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
using QDoorCheck.Common;

namespace IDE
{
    public partial class HomePage : BasePage 
    {
        database mydb = new database();
        CSVHelper CSVs = new CSVHelper();
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            { 
                if (this.Request.ServerVariables["LOGON_USER"] == "")
                {
                    //this.Response.Redirect("./Login.aspx");
                }

                InitializeCulture();


            }         

        }


        /// <summary>
        /// 中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LB_CN_Click(object sender, EventArgs e)
        {
            Session["language"] = "zh-CN";

            this.Response.Redirect("~/HomePage.aspx");

        }


        /// <summary>
        /// 英文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LB_EN_Click(object sender, EventArgs e)
        {
            Session["language"] = "en-US";
            this.Response.Redirect("~/HomePage.aspx");
           
        }


    }

}