<%@ WebHandler Language="C#" Class="search" %>

using System;
using System.Web;

using BO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class search : BaseHandler.MyBaseHandler 
{
    public override void DispatchAct(string actName)
    {
        switch (actName)
        {
            case "GetAllAreas":
                GetAllAreas();
                break;
            case "Search":
                SearchRecord();
                break;
            default:
                WriteActNotSupportMsg();
                break;
        }
    }

    void GetAllAreas()
    {
        List<Area> areas=Area.GetAllAreas();
        areas.Sort(new Comparison<Area>(delegate(Area item1, Area item2)
        {
            return item1.AreaName.CompareTo(item2.AreaName);
        }));
        string areasStr= BaseHandler.JsonSerializer.Serialize(areas);
        areasStr = Regex.Replace(areasStr, @"""\\/Date\((?<tick>\d+)\)\\/""", @"new Date(${tick})", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        
        this.WriteText(areasStr);        
    }

    void SearchRecord()
    {
        string areaId = this.GetPara("area");
        string keyvalue = this.GetPara("keyValue").Trim();
        DateTime from =DateTime.Parse(this.GetPara("from"));
        DateTime to =DateTime.Parse(this.GetPara("to")).AddDays(1d);

        List<BO.v_objects.v_checkRec> recs = BO.DBAccess.DB_Search.Search(areaId, keyvalue,from,to);
        string recsStr = BaseHandler.JsonSerializer.Serialize(recs);

        recsStr = Regex.Replace(recsStr, @"""\\/Date\((?<tick>\d+)\)\\/""", @"new Date(${tick})", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        this.WriteText(recsStr);
    }

}