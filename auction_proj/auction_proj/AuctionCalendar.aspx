<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionCalendar.aspx.cs" Inherits="auction_proj.AuctionCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Calendar ID="Calendar1" runat="server" style="margin-left: 42px; margin-top: 38px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <br />
        <br />
        <asp:Button ID="backToHome" runat="server"  Text="Back To Home" OnClick="backToHome_Click"  style="margin-left: 42px; margin-top: 0px" />

    </div>
    </form>
</body>
</html>
