<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionCalendar.aspx.cs" Inherits="auction_proj.AuctionCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 149px;
        }
        .auto-style3 {
            width: 268px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Calendar ID="Calendar1" runat="server" style="margin-left: 42px; margin-top: 38px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="235px" NextPrevFormat="FullMonth" VisibleDate="2017-05-04" Width="436px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="Black" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BorderColor="#666666" />
            </asp:Calendar>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Selected Date:</td>
                    <td class="auto-style3">
                        <asp:Label ID="selectedDateLabel" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Number of Auctions:</td>
                    <td class="auto-style3">
                        <asp:Label ID="NumberOfAuctLabel" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="AuctionNamesLabel" runat="server" Text="Auction Name's:"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Auct1NameLabel" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="GotoAuct1" runat="server" BackColor="#FFFFCC" Text="Go to Auction" OnClick="GotoAuct1_Click" OnClientClick="AuctionDetailPage.aspx" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Auct2NameLabel" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="GotoAuct2" runat="server" BackColor="#FFFFCC" Text="Go to Auction" OnClick="GotoAuct2_Click" />
                    </td>
                </tr>
            </table>
        <br />
        <br />
        <asp:Button ID="backToHome" runat="server"  Text="Back To Home" OnClick="backToHome_Click"  style="margin-left: 42px; margin-top: 0px" />

    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
