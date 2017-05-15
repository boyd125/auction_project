<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="empReg.aspx.cs" Inherits="auction_proj.empReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 89%;
            float: left;
        }
        .auto-style2 {
            width: 206px;
        }
        .auto-style4 {
            width: 206px;
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
        .auto-style12 {
            height: 26px;
            width: 282px;
        }
        .auto-style13 {
            width: 282px;
        }
        .auto-style14 {
            width: 257px;
            height: 26px;
        }
        .auto-style15 {
            width: 257px;
        }
        .auto-style16 {
            width: 191px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 369px; width: 681px">
     
        <br />
        <asp:Label ID="editLabel" runat="server" Font-Underline="True" Font-Size="Larger" Text="Register New Profile" Font-Bold="True" ForeColor="#66CCFF" ></asp:Label>
       
        <br />
       
        <br />
                    <asp:RadioButtonList ID="accountSelect" runat="server" OnSelectedIndexChanged="accountSelect_SelectedIndexChanged">
                        <asp:ListItem>NPO Rep</asp:ListItem>
                        <asp:ListItem>Employee</asp:ListItem>
                    </asp:RadioButtonList>
        <br />
      
           
           
        </table>
        <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style12">
        <asp:Label ID="nameInputLabel" runat="server" Font-Bold="true" Text="Name: " ></asp:Label>
                </td>
                <td class="auto-style5">
        <asp:TextBox ID="nameInput" runat="server" Width="154px" ></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nameInput" ErrorMessage="Must enter Name" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
        <asp:Label ID="phoneLabel" runat="server" Font-Bold="true" Text="Phone Number: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="phoneInput" runat="server" Width="153px" >000-000-0000</asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="phoneInput" ErrorMessage="Not a valid Phone#" Font-Bold="True" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
        <asp:Label ID="emailILabel" runat="server" Font-Bold="true" Text="Email: " ></asp:Label>
                </td>
                <td class="auto-style6">
        <asp:TextBox ID="emailInput" runat="server" Width="154px" ></asp:TextBox>

                </td>
                <td class="auto-style2">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailInput" ErrorMessage="Not a valid Email" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
                 <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style16">
                </td>
            </tr>
            <br />
            <tr>
                <td class="auto-style14">
          <asp:Label ID="passLabel" runat="server" Font-Bold="True" Text="Password: " ></asp:Label>

                </td>
                <td class="auto-style9">
        <asp:TextBox ID="passTB" runat="server" Width="157px" TextMode="Password" ></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="passTB" ErrorMessage="Must enter a Password" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <br />
             <tr>
                <td class="auto-style14">
          <asp:Label ID="passConfirmLabel" runat="server" Font-Bold="True" Text="Confirm Password: "></asp:Label>

                </td>
                <td class="auto-style9">
        <asp:TextBox ID="confirmTB" runat="server" Width="157px" TextMode="Password" ></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="passTB" ControlToValidate="confirmTB" ErrorMessage="Passwords must match" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>



            <br />
                <td class="auto-style15">
                   
                                       
                    <br />
                    <br />

                     <asp:Button ID="editProfSubmit" runat="server" Text="Submit" OnClick="editProfSubmit_Click" BackColor="#FFFFCC" ForeColor="Black"  />
             <br /> 
                     <asp:Button ID="backToHome" runat="server" Text="Back To Home" OnClick="backToHome_Click" />


                </td>
            </tr>
        </table>
        <br />

       
    </div>
        <div>
            <table align="right" class="auto-style1">
      
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
               
      
        </table>
        </div>
<br />
               
      
    </form>
</body>
</html>
