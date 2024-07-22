<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div style="width:300px; border:solid 1px gray; background-color:WhiteSmoke">
    <table>
    <tr> 
    <td colspan="2" align="center"><h2>登錄</h2></td>
    </tr>
    <tr><td>帳號:</td><td><asp:TextBox runat="server" ID="c_account" Width="100" MaxLength="50" ></asp:TextBox></td></tr>
    <tr><td>密碼:</td><td><asp:TextBox runat="server" ID="c_password" Width="100" MaxLength ="30" TextMode="password"></asp:TextBox></td></tr>
    <tr><td></td><td><asp:Label ID="c_msg" runat="server" ForeColor="red"></asp:Label></td></tr>
    <tr><td>&nbsp;</td><td><asp:Button runat="server" ID="c_ok" Text="OK" OnClick="c_ok_Click" /></td></tr>
    <tr><td></td><td>&nbsp;</td></tr>
    </table>
    </div>
    </form>
    </center>
</body>
</html>
