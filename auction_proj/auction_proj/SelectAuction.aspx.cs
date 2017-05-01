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
        private static int myOrBrowse = -1;
        private String nameOfPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            if (myOrBrowse == 0)
            {
                Label1.Text = "Current Auctions";
            }
           else if(myOrBrowse == 1)
            {
                Label1.Text = "My Auctions";
            }
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            //clear list box 1
            ListBox1.Items.Clear();
            List<string> auctions = dbClass.all_auctions();
            foreach(string auction in auctions)
            {
                ListBox1.Items.Add(auction);
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            index = ListBox1.Text;
           if(index != "")
            {
                AuctionDetailPage.setAuction(index);
                Response.Redirect("~/AuctionDetailPage.aspx");
            }
           
        }
        public static void setMyOrBrowseAuctions(int num)
        {
            if(num == 1 || num == 0)
            {
                myOrBrowse = num;
            }  
        }
        public static void setMyOrBrowseAuctions(int num, String id)
        {
            if(num == 1)
            {
                myOrBrowse = num;
                //nameOfPerson = id;
            }
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}