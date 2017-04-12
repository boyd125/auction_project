using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class auctionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            Label1.Text = SelectAuction.index + " Auction Page";
            if (SelectAuction.index == "WWO")
                ListBox1.Items.Add("Faux Fur Coat");
            if (SelectAuction.index == "UNICEF")
                ListBox1.Items.Add("Finger Painting");
            if (SelectAuction.index == "Red Cross")
                ListBox1.Items.Add("Bandages");
        }
    }
}