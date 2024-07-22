using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace MTSWeb.ASCX
{
    public partial class Pages : System.Web.UI.UserControl
    {       
            public string pagehtml = "";
            public int pagenum = 10;//设置每个分组有多少页码
            int startindex = 1;//起始页码
            protected void Page_Load(object sender, EventArgs e)
            { 
            
             }
            public void showthanklist(DataTable dt, Repeater Repeater1, int curpage, string cururl, string abso, int pagesize)
            {
                //分页核心代码
                PagedDataSource pagedata = new PagedDataSource();
               //DataTable dt = LoadRepeater(id.ToString());

                pagedata.DataSource = dt.DefaultView;
                pagedata.PageSize = pagesize;
                pagedata.AllowPaging = true;
                int half = 1;
                while ((half + 1) * 2 < pagenum) { half++; }
                int start = 1;
                int end = 1;

                if (curpage > pagedata.PageCount || curpage < 1) curpage = 1;
                pagedata.CurrentPageIndex = curpage - 1;
                //如果页面总数小于分组数量.
                if (pagenum >= pagedata.PageCount)
                { end = pagedata.PageCount; getPageindex(start, end, curpage, cururl, pagesize); }
                else
                {
                    if (curpage - half > 0)
                    {
                        start = curpage - half;
                        if (curpage + half > pagedata.PageCount)
                        {
                            start = pagedata.PageCount - pagenum + 1;
                            end = pagedata.PageCount;
                        }
                        else
                            end = curpage + half;

                    }
                    else
                    {
                        start = 1;
                        end = pagenum > pagedata.PageCount ? pagedata.PageCount : pagenum;
                    }

                    getPageindex(start, end, curpage, cururl, pagesize);
                }
                //jlcount.Text = Convert.ToString(dt.Rows.Count);
               // crpage.Text = Convert.ToString(curpage);
               // pgcount.Text = Convert.ToString(pagedata.PageCount);
                if (pagedata.PageCount == 1) //如果只有一个分组
                {
                    HLpre.CssClass = "prefalse";
                    HLnext.CssClass = "nextfalse";
                    HLfst.CssClass = "fstfalse";
                    HLlst.CssClass = "lstfalse";
                }
                else if (curpage == pagedata.PageCount && curpage > 1)//如果当前分组是最后一个分组
                {
                    HLpre.Enabled = true;
                    HLnext.Enabled = false;
                    HLpre.NavigateUrl = abso + cururl + "&page=" + (curpage - 1);
                    HLfst.Enabled = true;
                    HLfst.NavigateUrl = abso + cururl + "&page=1";
                    HLfst.Enabled = true;
                    HLfst.NavigateUrl = abso + cururl + "&page=1";
                    HLnext.CssClass = "nextfalse";
                    HLlst.CssClass = "lstfalse";
                }
                else if (curpage == 1 && curpage < pagedata.PageCount)
                {
                    HLpre.Enabled = false;
                    HLnext.Enabled = true;
                    HLfst.Enabled = false;
                    HLlst.Enabled = true;
                    HLlst.NavigateUrl = abso + cururl + "&page=" + Convert.ToString(pagedata.PageCount);
                    HLnext.NavigateUrl = abso + cururl + "&page=" + (curpage + 1);
                    HLfst.CssClass = "fstfalse";
                    HLpre.CssClass = "prefalse";
                }
                if (curpage > 1 && curpage < pagedata.PageCount)//如果当前分组处在中间
                {
                    HLpre.Enabled = true;
                    HLpre.NavigateUrl = abso + cururl + "&page=" + (curpage - 1);
                    HLnext.NavigateUrl = abso + cururl + "&page=" + (curpage + 1);
                    HLnext.Enabled = true;
                    HLfst.Enabled = true;
                    HLfst.NavigateUrl = abso + cururl + "&page=1";
                    HLlst.Enabled = true;
                    HLlst.NavigateUrl = abso + cururl + "&page=" + Convert.ToString(pagedata.PageCount);
                }

                Repeater1.DataSource = pagedata;
                Repeater1.DataBind();
            }
            //设置分页样式
            private void getPageindex(int start, int end, int curpage, string cururl, int pagesize)
            {
                pagehtml = "";
                

                for (int i = start; i <= end - 1; i++)
                {
                    if (curpage == i)
                    { pagehtml += "<b href='" + cururl + "&page=" + Convert.ToString(i + startindex - 1) + "' class='aa" + Convert.ToString(i + startindex - 1) + "'>" + Convert.ToString(i + startindex - 1) + "</b>"; }
                    else
                    {
                        pagehtml += "<a href='" + cururl + "&page=" + Convert.ToString(i + startindex - 1) + "' class='a" + Convert.ToString(i + startindex - 1) + "'>" + Convert.ToString(i + startindex - 1) + "</a>";
                    }

                }              

                if (curpage == end) 
                {
                    pagehtml += "<b id='lastid' href='" + cururl + "&page=" + Convert.ToString(end + startindex - 1) + "' class='aa" + Convert.ToString(end + startindex - 1) + "'>" + Convert.ToString(end + startindex - 1) + "</b>";
                }
                else
                {
                    pagehtml += "<a id='lastid' href='" + cururl + "&page=" + Convert.ToString(end + startindex - 1) + "' class='a" + Convert.ToString(end + startindex - 1) + "'>" + Convert.ToString(end + startindex - 1) + "</a>";
                }
            }
        }
    
}