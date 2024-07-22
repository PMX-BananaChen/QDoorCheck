<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetUse.aspx.cs" Inherits="IDE.AssetUse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="./EasyUI/themes/default/easyui.css">  
    <link rel="stylesheet" type="text/css" href="./EasyUI/themes/icon.css">
    <link rel="stylesheet" type="text/css" href="./EasyUI/demo.css">
    <script type="text/javascript" src="./EasyUI/jquery.min.js"></script>
    <script type="text/javascript" src="./EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="JS/EasyuiToExcel.js"></script>


    <style type="text/css">
        
        body,html
        {
            padding:0px;
            margin:0px;
        }

        .auto-style3 {
            width: 153px;
            text-align: right;
            height: 28px;
        }
        .auto-style4 {
            width: 299px;
            height: 28px;
        }
        .auto-style5 {
            height: 28px;
        }

        .auto-style6 {
            width: 153px;
            text-align: right;
            height: 36px;
        }
        .auto-style7 {
            width: 299px;
            height: 36px;
        }
        .auto-style8 {
            height: 36px;
        }

        .auto-style9 {
            width: 153px;
            text-align: right;
            height: 27px;
        }
        .auto-style10 {
            width: 299px;
            height: 27px;
        }
        .auto-style11 {
            height: 27px;
        }

    </style>

   <script type="text/javascript" >

       $(function () {

           $("#BU").combobox({

               url: 'Combobox.ashx',
               method: 'get',
               valueField: 'value',
               textField: 'text',
               groupField: 'group'              

           });
       });


      
       $(function () {

           $('#Sub_Search').click(function () {


               //至少保證有一個條件不為空,否則提醒用戶:

               if ($('#BU').combobox('getValue') == "" ) {

                   $('#ie6-warning').css('display', 'block');
                   $('#Mesage').text("提醒:必須保證至少一個查詢條件不為空!");

                   return false;

               }
               else {


                   $('#ie6-warning').css('display', 'none');

                   var qParams = { AreaName: $('#BU').combobox('getValue') }; //取得查詢參數


                   var opt = $('#dg');

                   opt.datagrid({
                       width: "auto", //自動寬度
                       height: 360,  //固定高度
                       nowrap: true, //不截斷內文
                       striped: true,  //列背景切換
                       fitColumns: false,  //自動適應欄寬
                       singleSelect: true,  //單選列
                       queryParams: qParams,  //參數
                       url: 'Information.ashx',  //資料處理頁
                       idField: 'sid',  //主索引                   
                       pageList: [10, 20, 30, 40, 50], //每頁顯示筆數清單
                       pagination: true, //是否啟用分頁
                       rownumbers: true, //是否顯示列數
                       columns: [[

                         { field: 'BU', title: 'BU', width: 60, align: 'center' },
                         { field: 'areaName', title: 'areaName', width: 100, align: 'center' },
                         { field: 'cardNo', title: 'cardNo', width: 80, align: 'center' },
                         { field: 'personName', title: 'Name', width: 80, align: 'center' },
                         { field: 'workNo', title: 'workNo', width: 60, align: 'center' },
                         { field: 'enableEnterIn', title: '允許進入', width: 80, align: 'center', formatter: function (value, row, index) { return '<img src="'+row.enableEnterIn+'" />' }},
                         { field: 'enableMoveMaterial', title: '允許移動材料', width: 80, align: 'center' , formatter: function (value, row, index) { return '<img src="'+row.enableMoveMaterial+'" />' }},
                         { field: 'enableMobile', title: '允許攜帶手機', width: 80, align: 'center', formatter: function (value, row, index) { return '<img src="'+row.enableMobile+'" />' }},
                         { field: 'enablePhoto', title: '允許拍照', width: 80, align: 'center' , formatter: function (value, row, index) { return '<img src="'+row.enablePhoto+'" />' }},
                         { field: 'enableLaptop', title: '允許攜帶电脑', width: 80, align: 'center', formatter: function (value, row, index) { return '<img src="' + row.enableLaptop + '" />' } },
                         { field: 'enableU', title: '允許攜帶U盘', width: 80, align: 'center', formatter: function (value, row, index) { return '<img src="' + row.enableU + '" />' } },
                         { field: 'isActive', title: '有效', width: 80, align: 'center', formatter: function (value, row, index) { return '<img src="' + row.isActive + '" />' } }

                       ]],

                       onClickRow: function (index) {
                           if (editIndex != index) {
                               if (endEditing()) {
                                   //$('#dg').datagrid('selectRow', index)
                                   //        .datagrid('beginEdit', index);
                                   editIndex = index;
                               } else {
                                   $('#dg').datagrid('selectRow', editIndex);
                               }
                           }
                       }



                   }).datagrid('getPager').pagination({
                       layout: ['list', 'sep', 'first', 'prev', 'sep', 'links', 'sep', 'next', 'last', 'sep', 'refresh']

                   });

               }

           });

       });


       //
       function Save_Excel() {
           //导出Excel文件
           //getExcelXML有一个JSON对象的配置，配置项看了下只有title配置，为excel文档的标题
           var data = $('#dg').datagrid('getExcelXml', { title: 'Excel' }); //获取datagrid数据对应的excel需要的xml格式的内容
           //用ajax发动到动态页动态写入xls文件中
           var url = 'ExportExcel.ashx'; //如果为asp注意修改后缀
           $.ajax({
               url: url, data: { data: data }, type: 'POST', dataType: 'text',
               success: function (fn) {
                   alert('导出excel成功！');
                   window.location = fn; //执行下载操作
               },
               error: function (xhr) {
                   alert('动态页有问题\nstatus：' + xhr.status + '\nresponseText：' + xhr.responseText)
               }
           });
           return false;
       }


       function editrowAdd() {

           var queryParams = $('#dg').datagrid('options').queryParams;
           var AreaName = queryParams.AreaName;          
           var page = 1;
           var rows = 10000;        

           window.open('./Information.ashx?page=' + page + '&rows=' + rows +
            '&AreaName=' + AreaName +          
            '', "gainover", "width=300,height=200,top=200,left=300");


       }



</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">

                </td>
                <td class="auto-style5"></td>
            </tr>           
            <tr>
                <td class="auto-style6"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LocalizedText,BUArea %>" />:</td>
                <td class="auto-style7"><input name="browser" id="BU" style="width:280px;" />

                </td>
                <td class="auto-style8">
                <asp:Image ID="Sub_Search" runat="server" ImageUrl="<%$ Resources:LocalizedText,Search %>" />

                ( <a href="#" onclick="editrowAdd()">導出excel</a> )</td>
            </tr>           
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>

    <table id="dg" style="width:100%;height:360px;" > </table>

    </div>
    </form>
</body>
</html>
