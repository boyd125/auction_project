<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionDetailPage.aspx.cs" Inherits="auction_proj.AuctionDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Label ID="auctName" runat="server" Text="NULL Auction" Font-Bold="true"></asp:Label>
        <br />
        <br />
        <asp:Label ID="auctOrg" runat="server" Text="Organization: "></asp:Label>
        <br />
        <asp:Label ID="auctLocation" runat="server" Text="Location: "></asp:Label>
        <br />
        <asp:Label ID="auctDate" runat="server" Text="Date: "></asp:Label>
        <br />
        <asp:Label ID="auctTime" runat="server" Text="Time: "></asp:Label>
        <br />
        <asp:Label ID="auctNumItems" runat="server" Text="Items: "></asp:Label>
        <br />
        <asp:Label ID="auctNumBidders" runat="server" Text="Number Of Bidders: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="backButt" runat="server" Text="Back To Browse" OnClick="backButt_Click" />
        <br />
        <br />
         <asp:Button ID="backToHome" runat="server" Text="Back To Home" OnClick="backToHome_Click" />
        

    
    </div>
    </form>
</body>
</html>
