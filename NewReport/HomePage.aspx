<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IDE.HomePage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>黑色专案</title>

<link rel="stylesheet" type="text/css" href="./EasyUI/themes/default/easyui.css">  
<link rel="stylesheet" type="text/css" href="./EasyUI/themes/icon.css">
<link rel="stylesheet" type="text/css" href="./EasyUI/demo.css">
<script type="text/javascript" src="./EasyUI/jquery.min.js"></script>
<script type="text/javascript" src="./EasyUI/jquery.easyui.min.js"></script>
<script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>


<script type="text/javascript">
   
    function open(text, url) {        

        if ($('#tt').tabs('exists', text)) {

            $('#tt').tabs('select', text);

        } else {

            $('#tt').tabs('add', {
                title: text,
                //href:url,
                content: "<iframe scrolling='yes' frameborder='0' src='"+url+"' style='width:100%;height:100%;'></iframe>",
                closable: true
            });

        }

    }


    $(function () {

        $('.nav').click(function () {

            var $text = $(this).text();
            var $url = $(this).attr('url');           

            open($text, $url);

        });

    });
   

</script>

    <style type="text/css">

        .Text_Seach
{
	border: 1px solid #dddddd;
	height: 20px;
	width:180px;   
    padding-left:5px;
}

        .butn{

           padding:2px; border:solid 1px #CCC;width:60px;

        }
        .body
        {
            padding:0px;
            margin:0px;
        }

#ie6-warning{
background:rgb(255,255,225);position: relative;top:0px;left:0px;
font-size:12px;color:#333;width:940px;padding: 10px;text-align:left;_height:100%; background:rgb(255,255,225) url('./images/Mention.gif') no-repeat 20px 12px; display:none; }
#ie6-warning a {text-decoration:none;}
#ie6-warning a:link,#ie6-warning a:visited{text-decoration:none; color:#03F; display:inline;}
#ie6-warning a:hover,#ie6-warning a:active{text-decoration:none; color:#69F; display:inline;}
.header{
  background-color: #E0ECFF;
  background: -webkit-linear-gradient(top,#EFF5FF 0,#E0ECFF 100%);
  background: -moz-linear-gradient(top,#EFF5FF 0,#E0ECFF 100%);
  background: -o-linear-gradient(top,#EFF5FF 0,#E0ECFF 100%);
  background: linear-gradient(to bottom,#EFF5FF 0,#E0ECFF 100%);
  background-repeat: repeat-x;
  filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#EFF5FF,endColorstr=#E0ECFF,GradientType=0);
}

#footer
{
    height: 40px;
    line-height: 40px;
    background-image: url(./images/buttom-copy-bg.gif);
    text-align: right;
    padding-right: 10px;
}

.content
{
    vertical-align: top;
    width: 195px;
}
.content ul
{
    width: 180px;
    margin: 0px;
    padding: 0px;
}
.content ul li
{
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    line-height: 26px;
    color: #333333;
    list-style-type: none;
    text-decoration: none;
    height: 26px;
    width: 180px;
    text-align: center;
    background-image: url(../images/menu_bg1.gif);
    background-repeat: no-repeat;
}
.content ul li a:link
{
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    line-height: 26px;
    color: #333333;
    background-image: url(../images/menu_bg1.gif);
    background-repeat: no-repeat;
    height: 26px;
    width: 180px;
    display: block;
    text-align: center;
    margin: 0px;
    padding: 0px;
    overflow: hidden;
    text-decoration: none;
}
.content ul li a:visited
{
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    line-height: 26px;
    color: #333333;
    background-image: url(./images/menu_bg1.gif);
    background-repeat: no-repeat;
    display: block;
    text-align: center;
    margin: 0px;
    padding: 0px;
    height: 26px;
    width: 180px;
    text-decoration: none;
}
.content ul li a:active
{
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    line-height: 26px;
    color: #333333;
    background-image: url(./images/menu_bg1.gif);
    background-repeat: no-repeat;
    height: 26px;
    width: 180px;
    display: block;
    text-align: center;
    margin: 0px;
    padding: 0px;
    overflow: hidden;
    text-decoration: none;
}
.content ul li a:hover
{
    font-family: Arial, Helvetica, sans-serif;
    font-size: 12px;
    line-height: 26px;
    font-weight: bold;
    color: #006600;
    background-image: url(./images/menu_bg2.gif);
    background-repeat: no-repeat;
    text-align: center;
    display: block;
    margin: 0px;
    padding: 0px;
    height: 26px;
    width: 180px;
    text-decoration: none;
}

.auto-style14 {
            width: 154px;
        }




 </style>

</head>

<body class="easyui-layout">
<form runat="server" >
    <div region="north" border="false" style="text-align: center; width: 1280px; height: 70px;"  class="header">
		<div id="header-inner">
				<table cellpadding="0" cellspacing="0" style="width:100%;">
					<tbody><tr>		
                        <td class="auto-style14"><img src="images/default-logo.gif" /></td>				
						<td style="height:70px;text-align:left;">
							<div style="color:#fff;font-size:22px;font-weight:bold;">
								&nbsp;&nbsp;
								<a href="/index.php" class="mytitle" style="color: #0E2D5F;font-size:16px;font-weight:bold;text-decoration:none"><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:LocalizedText,BlackProject %>" /></a>
							</div>

                            <div style="text-align:right;padding-right:50px;" runat="server" >
                                <asp:LinkButton ID="LB_CN" runat="server" OnClick="LB_CN_Click">中文</asp:LinkButton>/<asp:LinkButton ID="LB_EN" runat="server" OnClick="LB_EN_Click">英文</asp:LinkButton></div>
                            
						</td>
						
					</tr>
				</tbody></table>
			</div>
			
		</div>
    <div data-options="region:'south'" id="footer" style="height:32px;"></div>   
    <div runat="server" data-options="<%$ Resources:LocalizedText, MenuNavigator %>" style="width:185px;padding:0px;overflow:hidden;">

      <div class="easyui-accordion" style="width:180px; height: 300px;border:none;" >
      <div title="<%$ Resources:LocalizedText, ReportManagement %>" runat="server" style="width:180px;" class="content" >
      <ul>
      <li><a  url="AssetInformation.aspx" class="nav"> <asp:Literal ID="L2" runat="server" Text="<%$ Resources:LocalizedText,WorkshopAccess %>" /></a></li>
      <li><a  url="AssetUse.aspx" class="nav"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LocalizedText, AuthorizationManagement %>" /></a></li>
      <li><a  url="PersonInformation.aspx" class="nav"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LocalizedText, PersonInformation %>" /></a></li>     
      </ul></div> 

    </div>
 
    </div>

   
    <div data-options="region:'center',split:true" class="panel-body panel-body-noheader layout-body panel-noscroll" style="padding:0px;overflow:hidden;">
  
    <div id="tt" class="easyui-tabs tabs-container easyui-fluid" fit="true" border="false"  >   

    <div title="<%$ Resources:LocalizedText,WorkshopAccess %>"  runat="server" data-options="closable:false" style="padding:0px">

    <iframe name="iframeid" id="iframeid" scrolling='yes' frameborder='0' src='./AssetInformation.aspx' style='width:100%;height:100%;'></iframe>

　　</div>
       
    </div>  
 
        
</div>

 </form>

</body>

</html>