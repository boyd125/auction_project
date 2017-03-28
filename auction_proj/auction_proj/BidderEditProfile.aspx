<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidderEditProfile.aspx.cs" Inherits="auction_proj.BidderEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="editLabel" runat="server" Font-Underline="true"  Font-Size="Larger" Text="  Edit Profile  " Font-Bold="true" ></asp:Label>
        <br />
        <br />
        <asp:Label ID="nameInputLabel" runat="server" Font-Bold="true" Text="Name: " ></asp:Label>
        <asp:TextBox ID="nameInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="emailILabel" runat="server" Font-Bold="true" Text="Email: " ></asp:Label>
        <asp:TextBox ID="emailInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="phoneLabel" runat="server" Font-Bold="true" Text="Phone Number: " ></asp:Label>
        <asp:TextBox ID="phoneInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="addressLabel" runat="server" Font-Bold="true" Text="Address: " ></asp:Label>
        <asp:TextBox ID="addressInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="streetAdLabel" runat="server" Font-Bold="true" Text="Street: "></asp:Label>
        <asp:TextBox ID="streetInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="cityLabel" runat="server" Font-Bold="true" Text="City: "></asp:Label>
        <asp:TextBox ID="cityInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="stateLabel" runat="server" Font-Bold="true" Text="State: "></asp:Label>
        <asp:TextBox ID="stateInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="zipLabel" runat="server" Font-Bold="true" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="zipInput" runat="server" ></asp:TextBox>

        <br />
        <br />
        <asp:Button ID="editProfSubmit" runat="server" Text="Submit" OnClick="editProfSubmit_Click"  />

    </div>
  
    </form>
</body>
</html>
