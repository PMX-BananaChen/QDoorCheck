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
    public class New : IHttpHandler
    {
        database mydb = new database();

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "application/json";

            string Sku = context.Request["Sku"]; 
            string SN = context.Request["SN"];
            string cartonID = context.Request["cartonID"];
            string ManufactureDate = context.Request["ManufactureDate"];
            string CaseQty = context.Request["CaseQty"];
            string PO = context.Request["PO"];
            string PalletID = context.Request["PalletID"];    
            string User_id = context.Request["User_id"];

            mydb.con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString();    
            mydb.exec_sql("exec proc_insert '"+Sku+"','"+SN+"','"+cartonID+"','"+ManufactureDate+"','"+CaseQty+"','"+PO+"','"+PalletID+"','"+User_id +"'");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }

    
}