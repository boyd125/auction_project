<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectAuction.aspx.cs" Inherits="auction_proj.SelectAuction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
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
    </form>
</body>
</html>
