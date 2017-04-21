<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgProfile.aspx.cs" Inherits="auction_proj.OrgProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            float: left;
        }
        .auto-style2 {
            width: 183px;
        }
        .auto-style3 {
            height: 26px;
            width: 166px;
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
        .auto-style9 {
            width: 128px;
            height: 26px;
        }
        .auto-style10 {
            width: 188px;
            height: 26px;
        }
        .auto-style11 {
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 448px; width: 681px">
     
        <br />
        <asp:Label ID="editLabel" runat="server" Font-Underline="True" Font-Size="Larger" Text="  Edit Organization Profile  " Font-Bold="True" ForeColor="#66CCFF" ></asp:Label>
       
        <br />
        <br />
      
           
           
        </table>
        <table align="left" class="auto-style1">
               <tr>
                <td class="auto-style3">
        <asp:Label ID="orgName" runat="server" Font-Bold="true" Text="Organization: " ></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="orgNameInput" runat="server" Width="154px" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>
               <tr>
                <td class="auto-style3">
        <asp:Label ID="repLabel" runat="server" Font-Bold="true" Text="Representative" ></asp:Label>
                </td>
        
                <td class="auto-style4">
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
        <asp:Label ID="repNameInputLabel" runat="server" Font-Bold="true" Text="Name: " ></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="repNameInput" runat="server" Width="154px" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="repPhoneLabel" runat="server" Font-Bold="true" Text="Phone Number: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="repPhoneInput" runat="server" Width="153px" >(000) 000-0000</asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="repPhoneInput" ErrorMessage="Not a valid Phone#" Font-Bold="True" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="repEmailILabel" runat="server" Font-Bold="true" Text="Email: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="repEmailInput" runat="server" Width="154px" ></asp:TextBox>

                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="repEmailInput" ErrorMessage="Not a valid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <br />
            <br />
            <tr>
                <td class="auto-style11">
        <asp:Label ID="orgAddressLabel" runat="server" Font-Bold="True" Text="Address" ></asp:Label>
                </td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="orgStreetAdLabel" runat="server" Font-Bold="true" Text="Street: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="orgStreetInput" runat="server" Width="155px" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="orgCityLabel" runat="server" Font-Bold="true" Text="City: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="orgCityInput" runat="server" Width="155px" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="orgStateLabel" runat="server" Font-Bold="true" Text="State: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="orgStateInput" runat="server" Width="155px" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11">
        <asp:Label ID="orgZipLabel" runat="server" Font-Bold="true" Text="Zip Code: "></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="orgZipInput" runat="server" Width="157px" ></asp:TextBox>

                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="orgZipInput" ErrorMessage="Please enter Zip Code" Font-Bold="True" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                </td>
            </tr>
                 <table align="left" class="auto-style1">
            <br />
                <td class="auto-style11">
        <asp:Button ID="orgProfSubmit" runat="server" Text="Submit" OnClick="orgProfSubmit_Click" BackColor="#FFFFCC" ForeColor="Black"  />
                  

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
