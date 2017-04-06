<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BidderEditProfile.aspx.cs" Inherits="auction_proj.BidderEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 73%;
            float: left;
        }
        .auto-style2 {
            width: 183px;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            width: 183px;
            height: 26px;
        }
        .auto-style5 {
            width: 133px;
            height: 26px;
        }
        .auto-style6 {
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 369px; width: 681px">
     
        <br />
        <asp:Label ID="editLabel" runat="server" Font-Underline="true" Font-Size="Larger" Text="  Edit Profile  " Font-Bold="true" ></asp:Label>
       
        <br />
        <br />
      
           
           
        </table>
        <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style3">
        <asp:Label ID="nameInputLabel" runat="server" Font-Bold="true" Text="Name: " ></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="nameInput" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="phoneLabel" runat="server" Font-Bold="true" Text="Phone Number: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="phoneInput" runat="server" >(XXX) XXX-XXXX</asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="phoneInput" ErrorMessage="Not a valid Phone#" Font-Bold="True" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="emailILabel" runat="server" Font-Bold="true" Text="Email: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="emailInput" runat="server" ></asp:TextBox>

                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailInput" ErrorMessage="Not a valid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="addressLabel" runat="server" Font-Bold="true" Text="Address: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="addressInput" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="streetAdLabel" runat="server" Font-Bold="true" Text="Street: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="streetInput" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="cityLabel" runat="server" Font-Bold="true" Text="City: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="cityInput" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="stateLabel" runat="server" Font-Bold="true" Text="State: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="stateInput" runat="server" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="zipLabel" runat="server" Font-Bold="true" Text="Zip Code: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="zipInput" runat="server" ></asp:TextBox>

                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="zipInput" ErrorMessage="Please enter Zip Code" Font-Bold="True" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                 <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style3">
        <asp:Label ID="userLabel" runat="server" Font-Bold="true" Text="UserName: "  Visible="false"></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="userTB" runat="server" Visible="false" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>
            <br />
            <tr>
                <td class="auto-style3">
          <asp:Label ID="passLabel" runat="server" Font-Bold="true" Text="Password: " Visible="false" ></asp:Label>

                </td>
                <td class="auto-style5">
        <asp:TextBox ID="passTB" runat="server" Visible="false" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>
            <br />
             <tr>
                <td class="auto-style3">
          <asp:Label ID="passConfirmLabel" runat="server" Font-Bold="true" Text="Confirm Password: " Visible="false"></asp:Label>

                </td>
                <td class="auto-style5">
        <asp:TextBox ID="confirmTB" runat="server" Visible="false" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>



            <br />
                <td>
        <asp:Button ID="editProfSubmit" runat="server" Text="Submit" OnClick="editProfSubmit_Click"  />
                  

                </td>
            </tr>
        </table>
        <br />

       
    </div>
        <div>
            <table align="right" class="auto-style1">
      
           <asp:Button ID="backToHome" runat="server" Text="Back To Home" OnClick="backToHome_Click" />
               
      
        </table>
        </div>
  
    </form>
</body>
</html>
