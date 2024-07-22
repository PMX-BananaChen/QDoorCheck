<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetInformation.aspx.cs" Inherits="IDE.AssetInformation" %>

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
        .auto-style1 {
            width: 153px;
            text-align:right;
        }
        .auto-style2 {
            width: 300px;
        }

        body,html
        {
            padding:0px;
            margin:0px;
        }

        .auto-style3 {
            width: 153px;
            text-align: right;
            height: 31px;
        }
        .auto-style4 {
            width: 300px;
            height: 31px;
        }
        .auto-style5 {
            height: 31px;
        }

        .auto-style6 {
            width: 153px;
            text-align: right;
            height: 30px;
        }
        .auto-style7 {
            width: 300px;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }

        .auto-style9 {
            width: 153px;
            text-align: right;
            height: 23px;
        }
        .auto-style10 {
            width: 300px;
            height: 23px;
        }
        .auto-style11 {
            height: 23px;
        }

        .auto-style12 {
            width: 153px;
            text-align: right;
            height: 15px;
        }
        .auto-style13 {
            width: 300px;
            height: 15px;
        }
        .auto-style14 {
            height: 15px;
        }

    </style>

   <script type="text/javascript" >


       $(function () {
        
           $("#BU").combobox({                  

                   url: 'Combobox.ashx',
                   method: 'get',
                   valueField: 'text',
                   textField: 'text',
                   groupField: 'group'
                    //,
                   //onSelect: function (n, o) {

                   //    var $BU =$('#BU').combobox('getValue');

                   //    $('#cg').combogrid({
                   //        panelWidth: 500,
                   //        url: 'Person.ashx?BU='+$BU,
                   //        idField: 'sid',
                   //        textField: 'PersonName',
                   //        mode: 'remote',
                   //        fitColumns: true,
                   //        columns: [[
                   //            { field: 'CardNo', title: 'CardNo', width: 60 },
                   //            { field: 'PersonName', title: 'PersonName', width: 80 },
                   //            { field: 'WorkNo', title: 'WorkNo', align: 'right', width: 60 },
                   //            { field: 'depart', title: 'depart', align: 'right', width: 60 },
                   //            { field: 'job', title: 'job', width: 150 }

                   //        ]]

                   //    });  

                   //}

               });
       });


       //$(function () {

       //    var $BU = $('#BU').combobox('getValue');

       //    $('#cg').combogrid({
       //        panelWidth: 500,
       //        url: 'Person.ashx?BU=' + $BU,
       //        idField: 'sid',
       //        textField: 'PersonName',
       //        mode: 'remote',
       //        fitColumns: true,
       //        columns: [[
       //            { field: 'CardNo', title: 'CardNo', width: 60 },
       //            { field: 'PersonName', title: 'PersonName', width: 80 },
       //            { field: 'WorkNo', title: 'WorkNo', align: 'right', width: 60 },
       //            { field: 'depart', title: 'depart', align: 'right', width: 60 },
       //            { field: 'job', title: 'job', width: 150 }

       //        ]]

       //    });

       //});


        $(function () {

            $('#Sub_Search').click(function () {              

                //至少保證有一個條件不為空,否則提醒用戶:
             

                if ($('#BU').combobox('getValue') == "" && $('#cg').val() == "" && $("#Text1").val() == "" && $("#Text2").val() == "") {

                    $('#ie6-warning').css('display', 'block');
                    $('#Mesage').text("提醒:必須保證至少一個查詢條件不為空!");                  

                    return false;

                }
               else {
                               

                    $('#ie6-warning').css('display', 'none');

                    var qParams = { AreaName: $('#BU').combobox('getValue'), PersonId: $('#cg').val(), DateFrom: $("#Text1").val(), DateTo: $("#Text2").val() }; //取得查詢參數
                
                    var opt = $('#dg');

                    opt.datagrid({
                        width: "auto", //自動寬度
                        height: 360,  //固定高度
                        nowrap: true, //不截斷內文
                        striped: true,  //列背景切換
                        fitColumns: false,  //自動適應欄寬
                        singleSelect: true,  //單選列
                        queryParams: qParams,  //參數
                        url: 'Pagation.ashx',  //資料處理頁
                        idField: 'sid',  //主索引                   
                        pageList: [10,20,30,40,50], //每頁顯示筆數清單
                        pagination: true, //是否啟用分頁
                        rownumbers: true, //是否顯示列數
                        columns: [[

                          { field: 'BU', title: 'BU', width: 60, align: 'center'  },
                          { field: 'areaName', title: 'areaName', width: 100, align: 'center' },
                          { field: 'cardNo', title: 'cardNo', width: 60, align: 'center'},
                          { field: 'personName', title: 'Name', width: 60, align: 'center' },
                          { field: 'workNo', title: 'workNo', width: 60, align: 'center' },
                          { field: 'logtime', title: 'logtime', width: 120, align: 'center'},
                          { field: 'logcontent', title: 'logcontent', width: 340, align: 'center' }
                      
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
             $.ajax({ url: url, data: { data: data }, type: 'POST', dataType: 'text',
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
            var AreaName = encodeURIComponent(queryParams.AreaName);
            var PersonId=queryParams.PersonId;
            var DateFrom=queryParams.DateFrom;
            var DateTo=queryParams.DateTo;
            var page = 1;
            var rows = 10000;
          
            window.open('./Pagation.ashx?page=' + page + '&rows=' + rows + '&AreaName=' +AreaName + '&PersonId=' + PersonId + '&DateFrom=' + DateFrom + '&DateTo=' + DateTo + '', "gainover", "width=300,height=200,top=200,left=300");
          

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
                <td class="auto-style6"> <asp:Literal ID="L2" runat="server" Text="<%$ Resources:LocalizedText,BUArea %>" />:</td>
                <td class="auto-style7"><input class="easyui-combobox" name="browser" id="BU"  style="width:280px;" >

                </td>
                <td class="auto-style8"></td>
            </tr>           
            <tr>
                <td class="auto-style9"> <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LocalizedText,CENNo %>" />:</td>
                <td class="auto-style10">

                <input id="cg" style="width:280px" />

                </td>
                <td class="auto-style11">
                &nbsp;

                </td>
            </tr>
            <tr>
                <td class="auto-style1"> <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LocalizedText,AcessDate %>" />:</td>
                <td class="auto-style2">

                    <input id="Text1" name="Text1" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"  runat="server"  class="Wdate"  style="width:130px;" />-<input id="Text2" name="Text2" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd', maxDate: '%y-%M-%d' })"  runat="server"  class="Wdate" style="width:130px;" />

                </td>
                
                <td style="vertical-align: middle; line-height: 20px;">

                   <asp:Image ID="Sub_Search" runat="server" ImageUrl="<%$ Resources:LocalizedText,Search %>" />

                  ( <a href="#" onclick="editrowAdd()">導出excel</a> )
  
                </td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
            </tr>
        </table>
    </div>
    <div>

    <table id="dg" style="width:100%;height:360px;" > </table>

    </div>
    </form>
</body>
</html>
