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
// Go to Auction Buttons does not show unless there is an auction 
            int numValue;
            bool parsed = Int32.TryParse(Auct1NameLable.Text, out numValue);
            if (numValue == 1)
            {
                GotoAuct2.Visible = false;
            }
            else if (numValue != 2)
            {
                GotoAuct1.Visible = false;
                GotoAuct2.Visible = false;
            }
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selectedDateLable.Text = Calendar1.SelectedDate.ToLongDateString();

        }

        protected void GotoAuct2_Click(object sender, EventArgs e)
        {
          
        }
    }
}