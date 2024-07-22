<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        
    <link href="js/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery-ui-1.7.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/ui.datepicker.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
    <form id="form1">
    <div style="width:768px; border:solid 1px gray; background-color:WhiteSmoke">
    <div><h1>車間門禁記錄查詢</h1></div>
    <div style="text-align:left;">
    車間： &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <select id="areas" style="width:100px;">
    </select>
    <br />
    From:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" id="from" readonly="readonly" style="width:100px" />
    To:<input type="text" id="to" readonly="readonly" style="width:100px" />
    <br />
    工號/卡號/姓名：<input type="text" id="keyValue" style="width:200px;" />(不輸表示所有)    
    <input type="button" id="OK" value="OK" />&nbsp;&nbsp;<input type="button" id="exportToExcel" value="導出Excel" />
    <br /><br />
    </div>
    <div id="loading" style="display:none;" align="left">
    Loading...
    </div>
    <div id="view" align="left" align="left">
    </div>
    </div>
    </form>
</center>
</body>
<script src="js/lib/MicrosoftAjax.min.js" type="text/javascript"></script>
<script src="js/lib/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="js/lib/flexigrid.pack.js" type="text/javascript"></script>
<script src="js/ui/ui.core.js" type="text/javascript"></script>
<script src="js/ui/ui.datepicker.js" type="text/javascript"></script>
<script src="js/ui/jquery-ui-i18n.js" type="text/javascript"></script>
<script src="js/default.aspx.js" type="text/jscript"></script>
</html>
