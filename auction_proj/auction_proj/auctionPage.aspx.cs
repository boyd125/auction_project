using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            //make sure user is logged in
            if ((string)Session["loggedIn"] == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            if (!Page.IsPostBack)
            {
                //query for the bid
                if (HttpContext.Current.Session["account_type"].ToString() == "bidder")
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString);
                    conn.Open();
                    string strSQL = "Select Bid.auction as Organization, Bid.item as ID, " +
                        "Item_Auction_Id.item_name as Name, Bid.bid as Bid From Bid, " +
                        "Item_Auction_ID where Bid.bidder=@user and Item_Auction_ID.id = item";
                    SqlCommand scmd = new SqlCommand(strSQL, conn);
                    scmd.Parameters.AddWithValue("@user", HttpContext.Current.Session["account_email"]);
                    SqlDataReader reader = scmd.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    conn.Close();
                }
                if(HttpContext.Current.Session["account_type"].ToString() == "npo_rep")
                {
                    string org = "";
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString);
                    conn.Open();

                    string strSQL = "select org from Auction_Contact where contact = @account_email";
                    SqlCommand scmd = new SqlCommand(strSQL, conn);
                    scmd.Parameters.AddWithValue("@account_email", HttpContext.Current.Session["account_email"]);
                    using (SqlDataReader sreader = scmd.ExecuteReader())
                    {
                        while (sreader.Read() && sreader.HasRows)
                        {
                            org = sreader["org"].ToString();
                        }
                    }

                    strSQL = "select Name.item_name, Name.id, Auction_Bid.Total, Auction_Bid.Highest " +
                        "from (select * from Item_Auction_ID) as Name join(select item, count(bid) as Total, max(bid) as Highest from bid group by item) as Auction_Bid " +
                        "on Name.id = Auction_Bid.item where Name.auction = @org";

                    scmd = new SqlCommand(strSQL, conn);
                    scmd.Parameters.AddWithValue("@org", org);
                    SqlDataReader reader = scmd.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    conn.Close();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void backToHome_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Main.aspx");
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }

}