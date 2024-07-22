<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pages.ascx.cs" Inherits="MTSWeb.ASCX.Pages" %>

<div class="vc clearfix">

<%--<p>当前第&nbsp;&nbsp;<asp:Label ID="crpage" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;页/共&nbsp;&nbsp;<asp:Label ID="pgcount" runat="server" Text=""></asp:Label>&nbsp;&nbsp;页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;总共&nbsp;<asp:Label ID="jlcount" runat="server" Text=""></asp:Label>&nbsp;条记录&nbsp;&nbsp;</p>--%>
<asp:HyperLink ID="HLfst" runat="server" CssClass="fst">&nbsp;</asp:HyperLink><asp:HyperLink ID="HLpre" runat="server" CssClass="pre">&nbsp;</asp:HyperLink><%= pagehtml %><asp:HyperLink ID="HLnext" runat="server" CssClass="next">&nbsp;</asp:HyperLink><asp:HyperLink ID="HLlst" runat="server" CssClass="lst">&nbsp;</asp:HyperLink>

</div>