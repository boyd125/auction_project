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

namespace auction_proj
{
    public partial class login : System.Web.UI.Page
    {
        public static String username;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // In a using statement, acquire the SqlConnection as a resource.
            //

            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\senio102\Source\Repos\auction_project\auction_proj\auction_proj\App_Data\Database1.mdf; Integrated Security = True"))
            {
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                //SqlCommand command = new SqlCommand("SELECT * FROM Table1", con);
                //command.ExecuteNonQuery();
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Bidder 
                                        WHERE account_email=@uname and 
                                        account_password=@pass", con);
                    cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", TextBox2.Text);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        Label3.Text = ("Login Success");
                        username = TextBox1.Text;
                        Response.Redirect("~/Main.aspx");
                    }
                    else
                        Label3.Text = ("Incorrect login");
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
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Bidder (account_email, account_password) VALUES (@uname, @pass)", con);
                    cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", TextBox2.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Label3.Text = ("Unexpected error:" + ex.Message);
                }
            }
        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}