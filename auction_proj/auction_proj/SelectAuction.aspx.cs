using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class SelectAuction : System.Web.UI.Page
    {
        public static String index;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Welcome, " + user.email;
           // this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            //ListBox1.Items.Add("WWO");
            //ListBox1.Items.Add("UNICEF");
            //ListBox1.Items.Add("Red Cross");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            index = ListBox1.Text;
            Response.Redirect("~/auctionPage.aspx");
        }
    }
}