<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidderEditProfile.aspx.cs" Inherits="auction_proj.BidderEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="headerLabel" runat="server" Text="Edit Profile" Font-Bold="true" ></asp:Label>
        <br />
        <asp:Label ID="nameLabel" runat="server" Text="Name: " ></asp:Label>
        <asp:TextBox ID="nameInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="Email: " ></asp:Label>
        <asp:TextBox ID="emailInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="addressLabel" runat="server" Text="Address: " ></asp:Label>
        <asp:TextBox ID="addressInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="streetAdLabel" runat="server" Text="Street: "></asp:Label>
        <asp:TextBox ID="streetInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="cityLabel" runat="server" Text="City: "></asp:Label>
        <asp:TextBox ID="cityInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="stateLabel" runat="server" Text="State: "></asp:Label>
        <asp:TextBox ID="stateInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="zipLabel1" runat="server" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="zipInput" runat="server" ></asp:TextBox>

        <br />
        <asp:Button ID="editProfSubmit" runat="server" Text="Submit" OnClick="editProfSubmit_Click"  />

    </div>
    </form>
</body>
</html>
