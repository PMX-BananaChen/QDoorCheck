<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IDE.HomePage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>致伸科技</title>
<link href="./Style/style.css" rel="stylesheet" type="text/css" />
<link href="./Style/layout.css" rel="stylesheet" type="text/css" />    
<link rel="stylesheet" type="text/css" href="./EasyUI/themes/metro/easyui.css">
<link rel="stylesheet" type="text/css" href="./EasyUI/themes/icon.css">
<link rel="stylesheet" type="text/css" href="./EasyUI/demo.css">
<script type="text/javascript" src="./EasyUI/jquery.min.js"></script>
<script type="text/javascript" src="./EasyUI/jquery.easyui.min.js"></script>
<script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>


<script type="text/javascript">

    var editIndex = undefined;

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#dg').datagrid('validateRow', editIndex)) {
            var ed = $('#dg').datagrid('getEditor', { index: editIndex, field: 'Sku' });           
            $('#dg').datagrid('endEdit', editIndex);

            return true;

        } else {

            return false;
        }
    }
   
    function append() {
        if (endEditing()) {
            $('#dg').datagrid('appendRow', {  });
            editIndex = $('#dg').datagrid('getRows').length - 1;
            $('#dg').datagrid('selectRow', editIndex)
                    .datagrid('beginEdit', editIndex);
            editIndex = undefined;
            
        }
    }
    function removeit() {
        if (editIndex == undefined) { return }
        $('#dg').datagrid('cancelEdit', editIndex)
                .datagrid('deleteRow', editIndex);

        alert(editIndex);      


        //將數據保存到數據庫
        editIndex = undefined;


    }
    function accept() {
        if (endEditing()) {

            if (editIndex == undefined)
            {

                alert('增加');

            }
            else {

                alert('修改');

                //將數據保存到數據庫(修改)   

                var row = $('#dg').datagrid('getSelected');
                if (row) {
                    alert('Item ID:' + row.Sku + "\nPrice:" + row.sn);
                  }
               

            }          

            $('#dg').datagrid('acceptChanges');

        }

    }
    function reject() {
        $('#dg').datagrid('rejectChanges');
        editIndex = undefined;
    }
    function getChanges() {
        var rows = $('#dg').datagrid('getChanges');
        alert(rows.length + ' rows are changed!');
    }


    $(function () {
        var dg = $('#dg');
        dg.datagrid('loadData', []);
        dg.datagrid({ pagePosition:'bottom' });
        dg.datagrid('getPager').pagination({
            layout: ['list', 'sep', 'first', 'prev', 'sep', 'links', 'sep', 'next', 'last', 'sep', 'refresh']
        });
    });
    

    $(function () {

        $('#Button2').click(function () {

                var qParams = { id: $("#txtid").val(), name: $("#txtname").val() }; //取得查詢參數
                var oldRowIndex;
                var opt = $('#dg');
                opt.datagrid({
                    width: "auto", //自動寬度
                    height: 360,  //固定高度
                    nowrap: false, //不截斷內文
                    striped: true,  //列背景切換
                    fitColumns: false,  //自動適應欄寬
                    singleSelect: true,  //單選列
                    queryParams: qParams,  //參數
                    url: 'Pagation.ashx',  //資料處理頁
                    idField: 'id',  //主索引                   
                    pageList: [10, 20, 30, 40, 50], //每頁顯示筆數清單
                    pagination: true, //是否啟用分頁
                    rownumbers: true, //是否顯示列數
                    toolbar: '#tb', 
                    columns: [[

                      { field: 'Sku', title: 'Sku', width: 100, align: 'center', sortable: true, editor: 'text' },
                      { field: 'sn', title: 'SN', width: 110, align: 'center', sortable: true, editor: 'text' },
                      { field: 'cartonID', title: 'CartonID', width: 150, align: 'center', sortable: true, editor: 'text' },
                      { field: 'ManufactureDate', title: 'MFG. Date', width: 100, align: 'center', sortable: true, editor: 'datebox' },
                      { field: 'CaseQty', title: 'CaseQty', width: 60, align: 'center', sortable: true, editor: 'text' },
                      { field: 'PO', title: 'PO', width: 80, align: 'center', sortable: true, editor: 'text' },
                      { field: 'PalletID', title: 'PalletID', width: 110, align: 'center', sortable: true, editor: 'text' }

                    ]],

                    onClickRow: function (index) {
                        if (editIndex != index) {
                            if (endEditing()) {
                                $('#dg').datagrid('selectRow', index)
                                        .datagrid('beginEdit', index);
                                editIndex = index;
                            } else {
                                $('#dg').datagrid('selectRow', editIndex);
                            }
                        }
                    }


                }).datagrid('getPager').pagination({
                    layout: ['list', 'sep', 'first', 'prev', 'sep', 'links', 'sep', 'next', 'last', 'sep', 'refresh']
                });
              
            });       

    });


</script>

    <style type="text/css">

        .auto-style1 {
            width: 107px;
            text-align: right;
            height: 20px;
        }
        .auto-style2 {
            width: 205px;
        }
        .auto-style4 {
            width: 3px;
        }
        .auto-style5 {
            width: 68px;
        }
        .auto-style6 {
            width: 238px;
        }

        .auto-style7 {
            width: 205px;
            height: 20px;
        }
        .auto-style8 {
            width: 3px;
            height: 20px;
        }
        .auto-style9 {
            width: 238px;
            height: 20px;
        }
        .auto-style10 {
            width: 68px;
            height: 20px;
        }
        .auto-style11 {
            height: 20px;
        }

  .Text_Seach
{
	border: 1px solid #dddddd;
	height: 20px;
	width:200px;
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

 <table style="width: 100%;">
        <tr>
            <td class="auto-style1">Pack List:</td>
            <td class="auto-style7"> 

            <input id="Text3" type="text" class="Text_Seach" /></td>
            <td class="auto-style8"></td>
            <td class="auto-style9"></td>
            <td class="auto-style10"></td>
            <td class="auto-style11"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style1">PO#:</td>
            <td class="auto-style2">

            <input id="Text4" type="text" class="Text_Seach" /></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Pallet ID:</td>
            <td class="auto-style2">
                <input id="Text5" type="text" class="Text_Seach" /></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Carton ID:</td>
            <td class="auto-style2"> 
                <input id="Text6" type="text" class="Text_Seach" /></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">SN#:</td>
            <td class="auto-style2">
            <input id="Text7" type="text" class="Text_Seach" /></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">SKU:</td>
            <td class="auto-style2">
                <input id="Text8" type="text"  class="Text_Seach" /></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
               MFG. Date:
            </td>
            <td class="auto-style2">
                <input id="Text1" type="text" onclick="WdatePicker()" class="Wdate"  style="width:199px;" /></td>
            <td class="auto-style4">-</td>
            <td class="auto-style6">
                <input id="Text2" type="text" onclick="WdatePicker()" class="Wdate" style="width:199px;" /></td>
            <td class="auto-style5">
               <input id="Button2" type="button" value="查詢" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="發送FTP" OnClick="Button1_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
  </table>

</div>

<div id="tb" style="height:auto">
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="append()">Add</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="removeit()">Delete</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true" onclick="accept()">Save</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-undo',plain:true" onclick="reject()">Cancel</a>
</div>

<table id="dg" class="easyui-datagrid"  pagination="true"  style="width:100%;height:360px;">
          
</table>

</form>
</div>
</div>

<div id="copyright"> Copyright © 2014 Primax Electronics Ltd., All Rights Reserved.</div>
</div>
</body>
</html>

















