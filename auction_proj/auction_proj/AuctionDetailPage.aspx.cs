using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace auction_proj
{
    
    public partial class AuctionDetailPage : System.Web.UI.Page
    {
        private static String currentAuction;
        private String date, org, numItems, contact, intake, comments;

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ListBox1.SelectedValue;
            Label1.Text = item;
        }

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
            currentAuction = "Red Cross";
            //get the auction information from database
            List<string> info = dbClass.auction_info(currentAuction);

            if(info.Count != 0)
            {
                org = info[0];
                contact = info[1];
                date = info[2];
                intake = info[3];
                numItems = info[4];
                comments = info[5];
            }
            foreach (string i in dbClass.auction_items(currentAuction))
            {
                ListBox1.Items.Add(i);
                //Debug.WriteLine(i);
            }
               

            /*org = "Chapman University";
            location = "1 University Dr \n Orange, CA \n 92868";
            time = "8:30 AM PST";
            date = "19 April 2017 ";
            numItems = "150 items";
            registeredBidders = "3,500 persons";*/

            auctOrg.Text += org ;
            auctContact.Text += contact;
            auctDate.Text += date;
            auctIntake.Text += intake;
            auctNumItems.Text +=numItems;
            auctComments.Text += comments;

        }
        public static void setAuction(String auctionName)
        {
            currentAuction = auctionName;
        }

    }

}