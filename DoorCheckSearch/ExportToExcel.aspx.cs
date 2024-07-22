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

using System.Collections.Generic;
using System.IO;
using BO;
using BO.v_objects;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.Util;
using NPOI.HPSF;
using NPOI.SS.UserModel;

public partial class ExportToExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Export();
        }
        catch (Exception er)
        {
            Response.Write(er.ToString());
        }
    }

    private void Export()
    {
        string areaId = Request.QueryString["area"];
        string keyValue =Request.QueryString["keyValue"];

        if (string.IsNullOrEmpty(areaId))
        {
            Response.Write("Error params.");
            Response.End();
            return;
        }

        DateTime from = DateTime.Parse(Request.QueryString["from"]);
        DateTime to = DateTime.Parse(Request.QueryString["to"]).AddDays(1d);

        MemoryStream file = GetExcelFile(areaId, from, to, keyValue);
        ExportExcel(file);
    }

    void ExportExcel(MemoryStream file)
    {
        Response.Clear();
        Page.Culture = "zh-cn";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        string filename = string.Format("DoorCheck_{0}.xls", DateTime.Now.ToString("yyyyMMdd"));
        Response.AddHeader("content-disposition", "attachment;filename="+filename);
        Response.ContentType = "application/ms-excel";

        Response.BinaryWrite(file.ToArray());
        Response.End();
        Response.Flush();
    }

    MemoryStream GetExcelFile(string areaId, DateTime from, DateTime to, string keyValue)
    {
        HSSFWorkbook book = new HSSFWorkbook();
        
        Sheet sheet = book.CreateSheet("DoorCheck Log");        

        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        dsi.Company = "Primax.";

        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        si.ApplicationName = "車間門禁檢查";
        si.Author = "DoorCheck program";
        si.CreateDateTime = DateTime.Now;
        si.Title = "車間門禁檢查記錄";

        book.DocumentSummaryInformation = dsi;
        book.SummaryInformation = si;

        List<BO.v_objects.v_checkRec> recs = BO.DBAccess.DB_Search.Search(areaId, keyValue, from, to);

        //fill header row
        Row row= sheet.CreateRow(0);

        CellStyle style = book.CreateCellStyle();
        style.Alignment = HorizontalAlignment.CENTER;
        style.FillBackgroundColor = 225;
        Font font = book.CreateFont();
        font.Boldweight = 700;
        font.FontHeightInPoints = 10;
        style.SetFont(font);

        CellStyle dateStyle=book.CreateCellStyle();
        dateStyle.DataFormat=book.CreateDataFormat().GetFormat("yyyy-MM-dd HH:mm:ss");
        
        row.CreateCell(0, CellType.STRING).SetCellValue("NO.");
        row.CreateCell(1, CellType.STRING).SetCellValue("車間");
        row.CreateCell(2, CellType.STRING).SetCellValue("卡號");
        row.CreateCell(3, CellType.STRING).SetCellValue("工號");
        row.CreateCell(4, CellType.STRING).SetCellValue("姓名");
        row.CreateCell(5, CellType.STRING).SetCellValue("時間");
        row.CreateCell(6, CellType.STRING).SetCellValue("Memo");

        for (int i = 0; i < 7; i++)
        {
            row.GetCell(i).CellStyle = style;
        }

        sheet.SetColumnWidth(5, 20 * 256);
        sheet.SetColumnWidth(6, 80 * 256);

        //fill content
        for (int i = 0; i < recs.Count; i++)
        {
            Row contentRow = sheet.CreateRow(i + 1);

            contentRow.CreateCell(0, CellType.NUMERIC).SetCellValue(i+1);
            contentRow.CreateCell(1, CellType.STRING).SetCellValue(recs[i].Area);
            contentRow.CreateCell(2, CellType.STRING).SetCellValue(recs[i].PersonCard);
            contentRow.CreateCell(3, CellType.STRING).SetCellValue(recs[i].PersonWorkNo);
            contentRow.CreateCell(4, CellType.STRING).SetCellValue(recs[i].PersonName);
            contentRow.CreateCell(5).SetCellValue(recs[i].Time);
            contentRow.GetCell(5).CellStyle = dateStyle;
            contentRow.CreateCell(6, CellType.STRING).SetCellValue(recs[i].Memo);
        }

        //write to stream.
        MemoryStream ms = new MemoryStream();
        book.Write(ms);
        ms.Flush();
        ms.Position = 0;

        sheet.Dispose();
        book.Dispose();

        return ms;
        
    }
}
