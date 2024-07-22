using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.IO;

namespace Myclass
{

    //public class ExportCSVs
    //{

    //    /// <summary>
    //    /// Export the data from datatable to CSV file
    //    /// </summary>
    //    /// <param name="grid"></param>
    //    public void ExportDataGridToCSV(DataTable dt,string N )
    //    {
    //        string strFile = "";
    //        string path = "";
    //        strFile =DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + N;
    //        strFile = strFile + ".csv";
    //        path = HttpContext.Current.Server.MapPath("~/CSV/"+strFile); 
    //        System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
    //        StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
    //        //Tabel header
    //        for (int i = 0; i < dt.Columns.Count; i++)
    //        {
    //            sw.Write(dt.Columns[i].ColumnName);
    //            sw.Write("\t");
    //        }
    //        sw.WriteLine("");
    //        //Table body
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            for (int j = 0; j < dt.Columns.Count; j++)
    //            {
    //                sw.Write(DelQuota(dt.Rows[i][j].ToString()));
    //                sw.Write("\t");
    //            }
    //            sw.WriteLine("");
    //        }
    //        sw.Flush();
    //        sw.Close();

    //        DownLoadFile(path);
    //    }

    //    private bool DownLoadFile(string _FileName)
    //    {
    //        try
    //        {
    //            System.IO.FileStream fs = System.IO.File.OpenRead(_FileName);
    //            byte[] FileData = new byte[fs.Length];
    //            fs.Read(FileData, 0, (int)fs.Length);
    //            HttpContext.Current.Response.Clear();
    //            HttpContext.Current.Response.AddHeader("Content-Type", "application/notepad");
    //            string FileName = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(_FileName));
    //            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + System.Convert.ToChar(34) + FileName + System.Convert.ToChar(34));
    //            HttpContext.Current.Response.AddHeader("Content-Length", fs.Length.ToString());
    //            HttpContext.Current.Response.BinaryWrite(FileData);
    //            fs.Close();
    //            System.IO.File.Delete(_FileName);
    //            HttpContext.Current.Response.Flush();
    //            HttpContext.Current.Response.End();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            ex.Message.ToString();
    //            return false;
    //        }
    //    }



    //    /// <summary>
    //    /// Delete special symbol
    //    /// </summary>
    //    /// <param name="str"></param>
    //    /// <returns></returns>
    //    public string DelQuota(string str)
    //    {
    //        string result = str;
    //        string[] strQuota = { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?" };
    //        for (int i = 0; i < strQuota.Length; i++)
    //        {
    //            if (result.IndexOf(strQuota[i]) > -1)
    //                result = result.Replace(strQuota[i], "");
    //        }
    //        return result;
    //    }

    //}

    public class CSVHelper
    {
        //导出为svc文件,strFileName为要导出的csv格式文件的路径和文件名:比如，"d:\test\test.csv"
        public void ExportToSvc(System.Data.DataTable dt, string strPath)
        {  
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            //先打印标头
            //StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            int i = 0;
            try
            {
                //生成CSV文件

                StreamWriter sw = new StreamWriter(new FileStream(strPath, FileMode.CreateNew), Encoding.GetEncoding("GB2312"));

                //不需要生成表頭

                //for (i = 0; i <= dt.Columns.Count - 1; i++)
                //{
                //    strColu.Append(dt.Columns[i].ColumnName);
                //    strColu.Append(",");
                //}
                //strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符
                //sw.WriteLine(strColu);

                foreach (DataRow dr in dt.Rows)
                {
                    strValue.Remove(0, strValue.Length);//移出

                    for (i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        strValue.Append(dr[i].ToString());
                        strValue.Append(",");
                    }
                    strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符
                    sw.WriteLine(strValue);
                }

                sw.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            //System.Diagnostics.Process.Start(strPath);
        }
    }

}
