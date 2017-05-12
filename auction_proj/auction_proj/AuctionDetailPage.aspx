<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionDetailPage.aspx.cs" Inherits="auction_proj.AuctionDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 169px;
        }
        .auto-style3 {
            width: 72px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Label ID="auctName" runat="server" Text="NULL Auction" Font-Bold="true"></asp:Label>
        <br />
        <br />
        <asp:Label ID="auctOrg" runat="server" Text="Organization: "></asp:Label>
        <br />
        <asp:Label ID="auctContact" runat="server" Text="Contact: "></asp:Label>
        <br />
        <asp:Label ID="auctDate" runat="server" Text="Date & Time: "></asp:Label>
        <br />
        <asp:Label ID="auctIntake" runat="server" Text="Intake: "></asp:Label> 
        <br />     
        <asp:Label ID="auctNumItems" runat="server" Text="Items: "></asp:Label>
        <br />
        <asp:Label ID="auctComments" runat="server" Text="Comments: "></asp:Label>
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
        <asp:Label ID="itemsLabel" runat="server" Text="Items Available To Bid"></asp:Label>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label ID="currentBidderName" Visible="false"  runat="server" Text="Bidder Name"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:ListBox ID="itemsListBox"  runat="server" Width="130px" ></asp:ListBox>
                </td>
                <td class="auto-style3">
        <asp:Button ID="bidOnItemButton" Text="Bid" runat="server" BackColor="#FFFFCC" OnClick="bidOnItemButton_Click" />
                </td>
                <td>
                    <asp:Label ID="itemLabel" Visible="false" runat="server" Text="Item"></asp:Label>
                    <br />
                    <asp:Label ID="startingPrice" Visible="false" runat="server" Text="Starting Price: $100.00"></asp:Label>
                   <br />
                    <br />
                     <asp:Label ID="pLabel" Visible="false" runat="server" Text="Your Bid: $ "></asp:Label>
                    <asp:TextBox ID="bidInput" Visible="false" runat="server" Width="117px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="confirmPaymentButton" Visible="false" runat="server" Text="Confirm Bid" OnClick="confirmPaymentButton_Click" />
                </td>
            </tr>
        </table>
        <br />
       
        <br />
        <asp:Button ID="backButt" runat="server" Text="Back To Browse" OnClick="backButt_Click" />
        <asp:Button ID="Calendar" runat="server" OnClick="Calendar_Click" Text="View Calendar" />
        <br />
        <br />
         <asp:Button ID="backToHome" runat="server" Text="Back To Home" OnClick="backToHome_Click" />
        

    
    </div>
    </form>
</body>
</html>
