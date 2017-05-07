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
            GotoAuct1.Visible = false;
            GotoAuct2.Visible = false;
            AuctionNamesLabel.Visible = false;
            Auct1NameLabel.Visible = false;
            Auct2NameLabel.Visible = false;

            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
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
            // Inputs database info to labels
            NumberOfAuctLabel.Text = auctions.Count.ToString();

            if (NumberOfAuctLabel.Text == "0")
            {
                AuctionNamesLabel.Visible = false;
                Auct1NameLabel.Visible = false;
                Auct2NameLabel.Visible = false;
                GotoAuct1.Visible = false;
                GotoAuct2.Visible = false;
            }
            else if (NumberOfAuctLabel.Text == "1")
            {
                AuctionNamesLabel.Visible = true;
                Auct1NameLabel.Text = auctions.First().ToString();
                GotoAuct1.Visible = true;
                Auct1NameLabel.Visible = true;
                Auct2NameLabel.Visible = false;              
            }
            else if (NumberOfAuctLabel.Text == "2")
            {
                AuctionNamesLabel.Visible = true;
                Auct1NameLabel.Text = auctions.First().ToString();
                Auct2NameLabel.Text = auctions.Last().ToString();
                GotoAuct1.Visible = true;
                GotoAuct2.Visible = true;
                Auct1NameLabel.Visible = true;
                Auct2NameLabel.Visible = true;
            }
            
           

            // shows slected date
            selectedDateLabel.Text = Calendar1.SelectedDate.ToLongDateString();
           
            // If NumberofAuctLable is empty IE not pulling from database
            string s = NumberOfAuctLabel.Text;
            if (string.IsNullOrEmpty(s))
            {
                s = "Error: Not pulling from database";
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