<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="auction_proj.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="welcomeTB" Text="Welcome Bidder" Font-Bold="True" runat="server" ForeColor="#99CCFF"></asp:Label>
        <br />
        <asp:Label ID="whatLikeTodoTB" Text="What would you like to do?" Font-Italic="true" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="toDoDropDown" runat="server" BackColor="Silver">
            <asp:ListItem Text="--Select One--"  Enabled="True" Value="0"></asp:ListItem>
            <asp:ListItem Text="Browse Auctions"  Enabled="true" Value="1"></asp:ListItem>
             <asp:ListItem Text="My Bids"  Enabled="true" Value="2"></asp:ListItem>
            <asp:ListItem Text="View Calander"  Enabled="true" Value="3"></asp:ListItem>
             <asp:ListItem Text="My Profile"  Enabled="true" Value="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="submitToDo" runat="server" Text="  Go  " BackColor="#FFFFCC" ForeColor="Black" OnClick="submitToDo_Click" />

      
      
        <br />
        <br />
        <br />

      
      
    </div>
    </form>
</body>
</html>
