using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;

namespace auction_proj
{
    
    public partial class AuctionDetailPage : System.Web.UI.Page
    {
        
        
        private static String currentAuction;
        private String date, org, numItems, contact, intake, comments;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            auctName.Text = currentAuction + " Details";


            //FAKE DATA
            //currentAuction = "Red Cross";
            /*org = "Chapman University";
            location = "1 University Dr \n Orange, CA \n 92868";
            time = "8:30 AM PST";
            date = "19 April 2017 ";
            numItems = "150 items";
            registeredBidders = "3,500 persons";*/


            //get the auction information from database
            List<string> info = dbClass.auction_info(currentAuction);

            if (info.Count != 0)
            {
                org = info[0];
                contact = info[1];
                date = info[2];
                intake = info[3];
                numItems = info[4];
                comments = info[5];
            }

           if(itemsListBox.SelectedIndex == -1)
            {
                foreach (string i in dbClass.auction_items(currentAuction))
                {
                    itemsListBox.Items.Add(i);

                }

            }

           

            auctOrg.Text = "Organization: " + org;
            auctContact.Text = "Contact: " + contact;
            auctDate.Text = "Date & Time: " + date;
            auctIntake.Text = "Intake: " + intake;
            auctComments.Text = "Comments: " + comments;
            viewBids.Visible = false;

        }

        protected void Calendar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuctionCalendar.aspx");
        }

        protected void bidInput_TextChanged(object sender, EventArgs e)
        {

        }

        protected void viewBids_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/auctionPage.aspx");
        }

        protected void bidOnItemButton_Click(object sender, EventArgs e)
        {
            //show the bidding information
            currentBidderName.Text = (string)Session["full_name"];
            currentBidderName.Visible = true;
            int index = itemsListBox.SelectedIndex;
            if (index >= 0)
            {
                string name = itemsListBox.Items[index].Text;
                itemLabel.Text = name;
                itemLabel.Visible = true;
                startingPrice.Text = "Starting Price: $100.00";
                startingPrice.Visible = true;
                pLabel.Visible = true;
                bidInput.Visible = true;
                confirmPaymentButton.Visible = true;
            }
            else if (itemsListBox.SelectedIndex.Equals(-1))
             {
                    itemsListBox.Items.Clear();
                    Response.Redirect("~/AuctionDetailPage.aspx");
               
            }
            

        }

        protected void confirmPaymentButton_Click(object sender, EventArgs e)
        {
            double bid;
            bool result = Double.TryParse(bidInput.Text, out bid);
            //Makes bid input an integer above 0
            if(!result || bid == 0)
            {
                notValidLabel.Text = "Input must be greater than 0 and must be a number.";
                notValidLabel.Visible = true;
            }
            else
            {
                //send bid to database
                dbClass.insert_bid((string)HttpContext.Current.Session["account_email"], org, dbClass.get_item_id(itemsListBox.Items[itemsListBox.SelectedIndex].Text, org), int.Parse(bidInput.Text));
                notValidLabel.Visible = false;

                currentBidderName.Visible = false;
                itemLabel.Visible = false;
                startingPrice.Text = "Your bid has been recorded.";
                startingPrice.Visible = true;
                pLabel.Visible = false;
                bidInput.Visible = false;
                bidInput.Text = "0";
                confirmPaymentButton.Visible = false;
                viewBids.Visible = true;
            }
            
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
 
            Response.Redirect("~/Main.aspx");
        }

        protected void backButt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SelectAuction.aspx");
        }

       
        public static void setAuction(String auctionName)
        {
            currentAuction = auctionName;
        }

    }

}