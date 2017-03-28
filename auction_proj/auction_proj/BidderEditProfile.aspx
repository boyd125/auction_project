<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidderEditProfile.aspx.cs" Inherits="auction_proj.BidderEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 369px; width: 681px">
        <asp:Label ID="editLabel" runat="server" Font-Underline="true" Font-Size="Larger" Text="  Edit Profile  " Font-Bold="true" ></asp:Label>
        <br />
        <br />
        <table align="left" class="auto-style1">
            <tr>
                <td>
        <asp:Label ID="nameInputLabel" runat="server" Font-Bold="true" Text="Name: " ></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="nameInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="phoneLabel" runat="server" Font-Bold="true" Text="Phone Number: " ></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="phoneInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="emailILabel" runat="server" Font-Bold="true" Text="Email: " ></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="emailInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="addressLabel" runat="server" Font-Bold="true" Text="Address: " ></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="addressInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="streetAdLabel" runat="server" Font-Bold="true" Text="Street: "></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="streetInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="cityLabel" runat="server" Font-Bold="true" Text="City: "></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="cityInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="stateLabel" runat="server" Font-Bold="true" Text="State: "></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="stateInput" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="zipLabel" runat="server" Font-Bold="true" Text="Zip Code: "></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="zipInput" runat="server" ></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="editProfSubmit" runat="server" Text="Submit" OnClick="editProfSubmit_Click"  />

                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <br />
        <br />

    </div>
  
    </form>
</body>
</html>
