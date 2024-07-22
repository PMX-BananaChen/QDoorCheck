using QDoorCheck.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IDE
{
    public partial class AssetInformation : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!this.IsPostBack)
            {

                this.Text1.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                this.Text2.Value = DateTime.Now.ToString("yyyy-MM-dd");  


            }

        }

     



    }
}