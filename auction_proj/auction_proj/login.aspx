<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="auction_proj.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 134px;
        }
        .auto-style4 {
            width: 470px;
        }
        .auto-style5 {
            width: 547px;
        }
        .auto-style6 {
            width: 445px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Font-Names="Papyrus" Font-Size="XX-Large" ForeColor="#66CCFF" Text="Welcome"></asp:Label>
            <div style="text-align: center;">
                   <asp:Label ID="Label3" runat="server" Text="Please Login"></asp:Label>
                   </div>

            <table class="auto-style4" table align="center">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="username" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td class="auto-style2">
                   <asp:TextBox ID="TextBox1" runat="server" Width="175px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter login Email" ForeColor="#66CCFF"></asp:RequiredFieldValidator>
                    </td>

                    <td class="auto-style6">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter an Email" ControlToValidate="TextBox1" ForeColor="#66CCFF" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="password" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td class="auto-style2">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="174px">password</asp:TextBox>
                    </td>
                </tr>
            </table>
        <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" BackColor="#FFFFCC" BorderStyle="Outset" Font-Bold="False" Font-Italic="False" Font-Names="FrankRuehl" Height="25px" Width="57px" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Register" BackColor="#FFFFCC" BorderStyle="Outset" Font-Bold="False" Font-Italic="False" Font-Names="FrankRuehl" Height="25px" />
                   </p>
                         </div>
    </form>
</body>
</html>
