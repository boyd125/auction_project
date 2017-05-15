<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auctionPage.aspx.cs" Inherits="auction_proj.auctionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="15pt" Text="My Bids"></asp:Label>
    
    </div>
        <div style="margin-left: 40px">
            <br />
        </div>
      <asp:gridview id="GridView1" 
        autogeneratecolumns="False"
        emptydatatext="No data available." 
        runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
        <columns>
          <asp:boundfield datafield="auction" headertext="Organization"/>
          <asp:boundfield datafield="item" headertext="Item ID"/>
            <asp:BoundField DataField="item_name" HeaderText="Item Name" SortExpression="item_name" />
          <asp:boundfield datafield="bid" headertext="Bid Amount"/>
        </columns>

      </asp:gridview>
        <p>
         <asp:Button ID="backToHome" runat="server" Text="Back To Home" OnClick="backToHome_Click" />
        

    
        </p>
    </form>
</body>
</html>
