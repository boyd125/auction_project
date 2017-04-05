<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="auction_proj.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 134px;
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
        <p>
                   <asp:TextBox ID="TextBox1" runat="server" Height="17px">username</asp:TextBox>
                </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password">password</asp:TextBox>
        </p>
        <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" BackColor="#FFFFCC" BorderStyle="Outset" Font-Bold="False" Font-Italic="False" Font-Names="FrankRuehl" Height="25px" Width="57px" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Register" BackColor="#FFFFCC" BorderStyle="Outset" Font-Bold="False" Font-Italic="False" Font-Names="FrankRuehl" Height="25px" />
                   </p>
                         </div>
    </form>
</body>
</html>
