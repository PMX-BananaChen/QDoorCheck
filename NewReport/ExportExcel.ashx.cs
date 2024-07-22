using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace IDE
{
    /// <summary>
    /// Summary description for ExportExcel
    /// </summary>
    public class ExportExcel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
            string data = context.Request.Form["data"];
            File.WriteAllText(context.Server.MapPath(fn), data.Replace("./images/d.gif", "Yes").Replace("./images/c.gif", "No"), Encoding.UTF8);//如果是gb2312的xml申明，第三个编码参数修改为Encoding.GetEncoding(936)
            context.Response.Write(fn);//返回文件名提供下载
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