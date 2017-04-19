using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace auction_proj
{
    public class dbClass : System.Web.UI.Page
    {
        public static void update()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Bidder_All SET full_name=@name, phone=@phone, street=@street, city=@city, us_state=@state, zip = @zip" + " WHERE account_email=@Id", conn))
                    {

                        cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["account_email"]);
                        cmd.Parameters.AddWithValue("@name", HttpContext.Current.Session["full_name"]);
                        cmd.Parameters.AddWithValue("@phone", HttpContext.Current.Session["phone"]);
                        cmd.Parameters.AddWithValue("@street", HttpContext.Current.Session["street"]);
                        cmd.Parameters.AddWithValue("@city", HttpContext.Current.Session["city"]);
                        cmd.Parameters.AddWithValue("@state", HttpContext.Current.Session["us_state"]);
                        cmd.Parameters.AddWithValue("@zip", HttpContext.Current.Session["zip"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
            }
        }
    }
}