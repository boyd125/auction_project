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
            // In a using statement, acquire the SqlConnection as a resource.
            //

            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                //SqlCommand command = new SqlCommand("SELECT * FROM Table1", con);
                //command.ExecuteNonQuery();
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Bidder_All 
                                        WHERE account_email=@uname and 
                                        account_password=@pass", con);
                    cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", encrypt.encryptPass(TextBox2.Text));
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        Label3.Text = ("Login Success");
                        username = TextBox1.Text;
                        String user1 = TextBox1.Text;
                        string oString = "Select * from Bidder_All where account_email= @Fname";
                        SqlCommand oCmd = new SqlCommand(oString, con);
                        oCmd.Parameters.AddWithValue("@Fname", user1);
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                user.email = oReader["account_email"].ToString();
                                user.firstName = oReader["full_name"].ToString();
                                user.phone = oReader["phone"].ToString();
                                user.street = oReader["street"].ToString();
                                user.city = oReader["city"].ToString();
                                user.state = oReader["us_state"].ToString();
                                user.zip = oReader["zip"].ToString();
                                Session["account_email"] = user.email;
                                Session["full_name"] = user.firstName;
                                Session["phone"] = user.phone;
                                Session["street"] = user.street;
                                Session["city"] = user.city;
                                Session["us_state"] = user.state;
                                Session["zip"] = user.zip;
                                Session["loggedIn"] = "true";
                                Session["account_type"] = "bidder";
                            }
                        }
                        con.Close();
                        Response.Redirect("~/Main.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Label3.Text = ("Unexpected error:" + ex.Message);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // In a using statement, acquire the SqlConnection as a resource.
            //

            BidderEditProfile.whatChoice(2);
            Response.Redirect("~/BidderEditProfile.aspx");
        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}