using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data;
using Myclass;
using System.IO;
using System.Text;



namespace IDE
{
    public partial class Test : System.Web.UI.Page
    {

        database mydb = new database();

        protected void Page_Load(object sender, EventArgs e)
        {

          
            string json = QueryData();

            string aaa = json;
        

        }

        public string QueryData()
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

            List<Persons> li = new List<Persons>();

            DataSet ds_Local = mydb.mydataset("exec proc_load_Person '32F257B2-9AFA-4E9D-A783-6F505F7922D4' ");

            foreach (DataRow dr in ds_Local.Tables[0].Rows)
            {
                li.Add(new Persons()
                {
                    CardNo = dr["CardNo"].ToString(),
                    PersonName = dr["PersonName"].ToString(),
                    WorkNo = dr["WorkNo"].ToString(),
                    depart = dr["depart"].ToString(),
                    job = dr["job"].ToString(),
                    isActive = dr["isActive"].ToString()
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
            public List<Persons> rows { get; set; }
        }


        public class Persons
        {

            public string CardNo { get; set; }

            public string PersonName { get; set; }

            public string WorkNo { get; set; }

            public string depart { get; set; }

            public string job { get; set; }

            public string isActive { get; set; }


        }  

    }
}