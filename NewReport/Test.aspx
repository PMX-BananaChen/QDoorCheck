<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="IDE.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style9 {
            width: 199px;
        }
        .auto-style10 {
            height: 20px;
        }
        .auto-style13 {
            width: 166px;
        }
        .auto-style14 {
            height: 20px;
            width: 166px;
        }
    </style>
</head>
<body style="height: 400px; width: 806px">
    <form id="form1" runat="server">
    <div>


        <table style="width: 100%; height: 193px;">
            <tr>
                <td class="auto-style9" rowspan="6">&nbsp;</td>
                <td>卡号:</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">工号:</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style10">姓名:</td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td>部门:</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style1">职务:</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>有效:</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="4">
                  
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="areaName" HeaderText="管制区" SortExpression="areaName" />
                            <asp:BoundField DataField="enableEnterIn" HeaderText="允許進入" SortExpression="enableEnterIn" />
                            <asp:BoundField DataField="enablePhoto" HeaderText="允許拍照" ReadOnly="True" SortExpression="enablePhoto" />
                            <asp:BoundField DataField="enableMobile" HeaderText="允許攜帶手機" SortExpression="enableMobile" />
                            <asp:BoundField DataField="enableMoveMaterial" HeaderText="允許移動材料" SortExpression="enableMoveMaterial" />
                            <asp:BoundField DataField="enableLaptop" HeaderText="允許攜帶电脑" SortExpression="enableLaptop" />
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="4">
                  
                    &nbsp;</td>
            </tr>
        </table>
    
    
    </div>
    </form>
</body>
</html>
