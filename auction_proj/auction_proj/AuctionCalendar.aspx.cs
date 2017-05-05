using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class AuctionCalendar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
// Go to Auction Buttons does not show unless there is an auction on that date
            int numValue;
            bool parsed = Int32.TryParse(NumberOfAuctLabel.Text, out numValue);
            if (numValue == 1)
            {
                GotoAuct2.Visible = false;
            }
            else if (numValue != 2)
            {
                GotoAuct1.Visible = false;
                GotoAuct2.Visible = false;
                AuctionNamesLabel.Visible = false;

            }





        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // Pull from database
            string date;
            date = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            List<string> auctions = dbClass.auction_on_date(date);
            // Inputs database info to lables
            NumberOfAuctLabel.Text = auctions.Count.ToString();
            Auct1NameLabel.Text = auctions.ToString();


            selectedDateLabel.Text = Calendar1.SelectedDate.ToLongDateString();
            // If NumberofAuctLable is empty
            string s = NumberOfAuctLabel.Text;
            if (string.IsNullOrEmpty(s))
            {
                s = "No Auctions";
                NumberOfAuctLabel.Text = s;
            }
        }

        protected void GotoAuct2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuctionDetailPage.aspx");
        }

        protected void GotoAuct1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuctionDetailPage.aspx");
        }
    }
}