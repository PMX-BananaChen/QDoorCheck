using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;

namespace Myclass
{
    public static class xml
    {
        public static string GetStyle()
        {
          String xmlfile=HttpContext.Current.Server.MapPath("./Config/MyStyle.xml");  
          XmlDocument myDoc = new XmlDocument(); 
          myDoc.Load(xmlfile);
          XmlNodeList nodeList = myDoc.SelectSingleNode("Mystyles").ChildNodes;//获取Employees节点的所有子节点

         //學會用方法:ChildNodes.Item()查找子點;
         foreach (XmlNode node in nodeList)
         {
             if (node.ChildNodes.Item(4).InnerText == "1")
             {
                 return node.ChildNodes.Item(2).InnerText;
             }          

         }
         return null;
          //myDoc.ChildNodes.Item(1).ChildNodes.Item(0).FirstChild.InnerText  
          //myDoc.SelectSingleNode ("Mystyles/style/member[name=’Tim’]").ChildNodes.Item(1).InnerText ;    
     
        }

    }
}
