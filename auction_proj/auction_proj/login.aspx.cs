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
                // Open the SqlConnection.
                //
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT * FROM Table1", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
        }
    }
}