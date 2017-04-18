<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionCalendar.aspx.cs" Inherits="auction_proj.AuctionCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Calendar ID="Calendar1" runat="server" style="margin-left: 42px; margin-top: 38px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" VisibleDate="2017-04-18" Width="350px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="Black" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BorderColor="#666666" />
            </asp:Calendar>
        <br />
        <br />
        <asp:Button ID="backToHome" runat="server"  Text="Back To Home" OnClick="backToHome_Click"  style="margin-left: 42px; margin-top: 0px" />

    </div>
    </form>
</body>
</html>
