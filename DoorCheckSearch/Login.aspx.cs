using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void c_ok_Click(object sender, EventArgs e)
    {
        c_msg.Text = string.Empty;

        if (string.IsNullOrEmpty(c_account.Text.Trim()))
        {
            c_msg.Text = "請輸入帳號."; 
            return;
        }
        string account = this.c_account.Text;
        string password = this.c_password.Text;

        if (new BO.DBAccess.DB_Login().Login(account,password) )
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,account,DateTime.Now,DateTime.Now.AddMinutes(30),false,"");
            //Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            Response.Redirect("default.aspx");
        }
        else
        {
            c_msg.Text = "登錄失敗.";
        }
    }
}
