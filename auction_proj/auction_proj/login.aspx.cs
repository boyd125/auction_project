using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            //Login1.UserName
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
                    SqlCommand add = new SqlCommand(@"INSERT INTO Table1 (username, password) VALUES ('user22', 'pwd')", con);
                    add.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Table1 
                                        WHERE username=@uname and 
                                        password=@pass", con);
                    cmd.Parameters.AddWithValue("@uname", Login1.UserNameLabelText);
                    cmd.Parameters.AddWithValue("@pass", Login1.PasswordLabelText);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                        Label3.Text=("Login Success");
                    else
                        Label3.Text = ("Incorrect login");
                }
                catch (Exception ex)
                {
                    Label3.Text = ("Unexpected error:" + ex.Message);
                }
            }
        }
    }
}