/********************************************************************************
** Author£ºliuda
** Created On£º07/28/2008 10:16:50
** Function£ºMulti Language
** Modified By: wuzhuohui
** Modified On: 07/30/2008
** Comments: add some common method
** Modified By: liuda
** Modified On: 08/13/2008
** Comments: According to the browser's default language automatically choose language website
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Web.Configuration;
using System.Text;
using System.Web.Services;
using System.Collections.Generic;


namespace QDoorCheck.Common
{
    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// Request user select language. Add by liuda 20080802
        /// </summary>
        /// <param name="pValue">Message content</param>
        protected override void InitializeCulture()
        {
            if (Session["language"] == null && Request.QueryString["currentculture"] == null)
            {
                String defaultLang = Request.UserLanguages != null ? Request.UserLanguages[0] : "";
                if (defaultLang == "en-US")
                {
                    Session["language"] = "en-US";
                }
                else
                {
                    Session["language"] = "zh-CN";
                }
            }

            else if (Request.QueryString["currentculture"] != null)
            {
                Session["language"] = Request.QueryString["currentculture"];
            }

            String UseLanguage = Session["language"].ToString();

            if (!String.IsNullOrEmpty(UseLanguage))
            {
                //UICulture - What kind of a decision by the localization of resources,Also what language is used 
                //Culture - Decided to various types of data is how to organize
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(UseLanguage);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(UseLanguage);
            }

        }        
      
       
    }
}
