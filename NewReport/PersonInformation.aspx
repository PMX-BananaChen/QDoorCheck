<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonInformation.aspx.cs" Inherits="IDE.PersonInformation" %>

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

    <style type="text/css">

        .auto-style2 {
            width: 287px;
        }

        body,html
        {
            padding:0px;
            margin:0px;
        }

        .auto-style5 {
            height: 28px;
        }

        .auto-style6 {
            width: 133px;
          
            height: 47px;
        }
        .auto-style7 {
            width: 287px;
            height: 47px;
        }
        .auto-style8 {
            height: 47px;
        }

        .auto-style11 {
          
        }
        .auto-style13 {
            height: 17px;
        }

        .auto-style14 {
            width: 200px;
        }
        .auto-style18 {
            width: 56px;
            height: 47px;
        }
        .auto-style19 {
            width: 56px;
        }

        .auto-style20 {
            width: 133px;
        }

   #GridView1 td
   {
       border:none;      
       font-size:10px;  
      
   }

    #GridView1 th
   {
       border:none;      
       font-size:10px;
       font-weight:normal;  
       height:25px;
       
   }

   #GridView1 
   {
       border:none;      
       padding:5px;

   }

        .auto-style21 {
            width: 200px;
            height: 18px;
        }
        .auto-style23 {
            width: 200px;
            height: 17px;
        }
        .auto-style24 {
            height: 18px;
        }
        .auto-style25 {
            width: 200px;
            height: 16px;
        }
        .auto-style26 {
            height: 16px;
        }

    </style>

   <script type="text/javascript" >

       $(function () {

           $('#Sub_Search').click(function () {


               //至少保證有一個條件不為空,否則提醒用戶:

               if ($("#BU").val() == "" && $("#cg").val() == "" && $("#Text1").val() == "" && $("#Text2").val() == "") {

                   $('#ie6-warning').css('display', 'block');
                   $('#Mesage').text("提醒:必須保證至少一個查詢條件不為空!");

                   return false;

               }
               else {


                   $('#ie6-warning').css('display', 'none');

                 

               }

           });

       });

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td style="width:60px;">&nbsp;</td>
                <td class="auto-style20" ></td>
                <td >

                </td>
                <td class="auto-style5"></td>
            </tr>           
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style6"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LocalizedText,CENNo %>" />:</td>
                <td class="auto-style7">

                <input id="cg" style="width:280px;border:solid 1px #CCC;height:25px;line-height:25px;" runat="server" />

                </td>
                <td class="auto-style8">
                   
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="<%$ Resources:LocalizedText,Search %>" OnClick="ImageButton1_Click" />            

                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    
       
    <asp:Panel ID="Panel1" runat="server" Style="margin-top:70px;background-color:#f3f5f6;padding:20px 10px;font-size:10px;">

    <table  style="width: 100%; height: 193px;">
            <tr>
                <td style="width:20px;" rowspan="8">&nbsp;</td>
                <td class="auto-style14" rowspan="8">
                    <asp:Image ID="Image1" runat="server" Width="250px" Height="280px" />
                </td>
                <td style="width:20px;" rowspan="8">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LocalizedText,CardNo %>" />:&nbsp; <asp:Label ID="lb_cardno" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23"><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:LocalizedText,EmpNo %>" />:&nbsp; <asp:Label ID="lb_workno" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style13"><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:LocalizedText,Name %>" />:&nbsp; <asp:Label ID="lb_name" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:LocalizedText,Dept %>" />:&nbsp; <asp:Label ID="lb_depart" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style11"><asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:LocalizedText,Job %>" />:&nbsp;
                    <asp:Label ID="lb_job" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style25"><asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LocalizedText,Enable %>" />:&nbsp;
                    <asp:Label ID="lb_active" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style26"></td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="583px">
                        <Columns>
                            <asp:BoundField DataField="areaName" HeaderText="<%$ Resources:LocalizedText,AreaName %>" SortExpression="areaName">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowEnter %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enableEnterIn").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowedPhoto %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enablePhoto").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowedMoblie %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enableMobile").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowedMaterial %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enableMoveMaterial").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowedNotebook %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enableLaptop").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="<%$ Resources:LocalizedText,AllowedUSBDisk %>">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ImageButton1" runat="server" ImageUrl='<%# showVendorType(Eval("enableU").ToString())%>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            </table>

    </asp:Panel>

    </form>
</body>
</html>
