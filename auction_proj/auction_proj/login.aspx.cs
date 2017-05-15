using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Diagnostics;

namespace auction_proj
{
    public partial class login : System.Web.UI.Page
    {
        public static String username;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["loggedIn"] = "false";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                dbClass.login(TextBox1.Text, TextBox2.Text);
               
          
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // In a using statement, acquire the SqlConnection as a resource.
           
            BidderEditProfile.whatChoice(2);
            Response.Redirect("~/BidderEditProfile.aspx");
        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}