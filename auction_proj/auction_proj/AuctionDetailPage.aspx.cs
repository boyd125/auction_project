using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    
    public partial class AuctionDetailPage : System.Web.UI.Page
    {
        private static String currentAuction;
        private String date, time, org, numItems, location, registeredBidders;

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void backButt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectAuction.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            auctName.Text = currentAuction + " Details";

            //get the auction information from database

            org = "Chapman University";
            location = "1 University Dr \n Orange, CA \n 92868";
            time = "8:30 AM PST";
            date = "19 April 2017 ";
            numItems = "150 items";
            registeredBidders = "3,500 persons";

            auctOrg.Text += org ;
            auctLocation.Text += location;
            auctTime.Text += time;
            auctDate.Text += date;
            auctNumItems.Text +=numItems;
            auctNumBidders.Text +=registeredBidders;

        }
        public static void setAuction(String auctionName)
        {
            currentAuction = auctionName;
        }

    }

}