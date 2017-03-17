<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectAuction.aspx.cs" Inherits="auction_proj.SelectAuction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="20pt" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Current Auctions"></asp:Label>
    <div>
    
    </div>
        <div style="margin-left: 40px">
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Height="146px" Width="171px">
                <asp:ListItem>WWO</asp:ListItem>
                <asp:ListItem>UNICEF</asp:ListItem>
                <asp:ListItem>Red Cross</asp:ListItem>
            </asp:ListBox>
            <asp:Button ID="Button1" runat="server" OnClick="buttonClick" style="margin-left: 25px" Text="Proceed" />
        </div>
        <asp:Calendar ID="Calendar1" runat="server" style="margin-left: 42px; margin-top: 38px"></asp:Calendar>
    </form>
</body>
</html>
