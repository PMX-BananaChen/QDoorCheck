<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTPList.aspx.cs" Inherits="IDE.FTPList" %>
<%@ Register src="ASCX/Pages.ascx" tagname="Pages" tagprefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>致伸科技</title>
<link href="./Style/style.css" rel="stylesheet" type="text/css" />
<link href="./Style/layout.css" rel="stylesheet" type="text/css" /> 
<link href="Style/index.css" rel="stylesheet" type="text/css"  />
<link rel="stylesheet" type="text/css" href="./EasyUI/themes/metro/easyui.css">
<link rel="stylesheet" type="text/css" href="./EasyUI/themes/icon.css">
<link rel="stylesheet" type="text/css" href="./EasyUI/demo.css">
<script type="text/javascript" src="./EasyUI/jquery.min.js"></script>
<script type="text/javascript" src="./EasyUI/jquery.easyui.min.js"></script>
<script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>




    <style type="text/css">

        .auto-style1 {
            width: 107px;
            text-align: right;
            height: 20px;
        }
        .auto-style2 {
            width: 179px;
        }
        .auto-style4 {
            width: 3px;
        }
        .auto-style5 {
            width: 57px;
        }
        .auto-style6 {
            width: 213px;
        }

        .auto-style7 {
            width: 179px;
            height: 20px;
        }
        .auto-style8 {
            width: 3px;
            height: 20px;
        }
        .auto-style9 {
            width: 213px;
            height: 20px;
        }
        .auto-style10 {
            width: 57px;
            height: 20px;
        }
        .auto-style11 {
            height: 20px;
        }

  .Text_Seach
{
	border: 1px solid #dddddd;
	height: 20px;
	width:180px;   
    padding-left:5px;
}

        .auto-style12 {
            height: 20px;
            width: 80px;
        }
        .auto-style13 {
            width: 80px;
        }

    </style>

</head>
<body>

<div id="Wrapper">
<div class="Page">
<div id="nameplate">
<div class="MR" id="up1"><img src="images/logo.png" / style="margin-top: 5px;margin-left:8px;"></div>
</div>
<div class="TabCont">
<form id="form1" runat="server">
<div style="margin-top:20px;margin-bottom:20px;">

<table>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<tr style="margin:10px;height:25px;"><td style="width:40px;"></td><td style="width:30px;"><img src="images/files.gif" /></td><td style="width:340px;"><%#Eval("FileName")%></td><td style="width:220px;"><%#Eval("Date")%></td><td style="width:80px;"><a href='<%#Eval("path")%>'>流覽</a></td></tr>
</ItemTemplate>
</asp:Repeater>
</table> 

</div>
 <div id="Pager"  style="width:100%;text-align:left;padding-left:30px;margin-top:10px;color:Black;padding-top:20px; font-size: 14px; font-weight: bold;">
     
  <uc1:Pages ID="Pages1" runat="server" />
         
  </div>

</form>
</div>
</div>

<div id="copyright"> Copyright © 2014 Primax Electronics Ltd., All Rights Reserved.</div>
</div>
</body>
</html>


















