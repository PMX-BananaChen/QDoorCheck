using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Myclass;
using System.Data;
using QDoorCheck.Common;


namespace IDE
{

    public partial class PersonInformation : BasePage 
    {
        database mydb = new database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {

                this.Panel1.Visible = false;

            }


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            string cardNo = this.cg.Value;

            DataTable ds_Local = mydb.mydataset("exec proc_load_PersonInformation '" + cardNo + "' ").Tables[0];

            if (ds_Local.Rows.Count > 0)
            {

                //将数据库存的二进制的图片显示于imgae控件

                this.Panel1.Visible = true;

                //人员信息
                this.lb_cardno.Text = ds_Local.Rows[0]["cardNo"].ToString();
                this.lb_workno.Text = ds_Local.Rows[0]["workNo"].ToString();
                this.lb_name.Text = ds_Local.Rows[0]["personName"].ToString();
                this.lb_depart.Text = ds_Local.Rows[0]["depart"].ToString();
                this.lb_job.Text = ds_Local.Rows[0]["job"].ToString();
                this.lb_active.Text = ds_Local.Rows[0]["isActive"].ToString();

                string imagename = "";
                MemoryStream ms = new MemoryStream((Byte[])ds_Local.Rows[0]["photo"]);
                if (ms.Length != 0)
                {
                    Bitmap image = new Bitmap(ms);
                    string filepath = Server.MapPath("Files/");
                    DirectoryInfo dir = new DirectoryInfo(filepath);
                    FileInfo[] filecount = dir.GetFiles();
                    int i = filecount.Length;
                    imagename = filepath + ((i + 1) + ".jpg");
                    image.Save(imagename);
                    Image1.ImageUrl = "Files/" + ((i + 1) + ".jpg");
                }
                else
                {
                    Image1.ImageUrl = "Files/OOOP.gif";
                }

                this.GridView1.DataSource = ds_Local;
                this.GridView1.DataBind();

            }



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