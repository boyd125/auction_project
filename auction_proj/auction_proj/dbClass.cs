using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Diagnostics;

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
                    if ((string)HttpContext.Current.Session["account_type"] == "bidder")
                    {
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
                        conn.Close();
                    }

                    if ((string)HttpContext.Current.Session["account_type"] == "employee")
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE_All SET full_name=@name" + " WHERE account_email=@Id", conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["account_email"]);
                            cmd.Parameters.AddWithValue("@name", HttpContext.Current.Session["full_name"]);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }

                    if ((string)HttpContext.Current.Session["account_type"] == "npo_rep")
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE NPO_REP_All SET full_name=@name, phone=@phone" + " WHERE account_email=@Id", conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", HttpContext.Current.Session["account_email"]);
                            cmd.Parameters.AddWithValue("@name", HttpContext.Current.Session["full_name"]);
                            cmd.Parameters.AddWithValue("@phone", HttpContext.Current.Session["phone"]);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }

                    else
                    {
                        //exception handling?
                    }
                }
            }
            catch (SqlException ex)
            {
            }
        }

        public static List<string> all_auctions()
        {
            List<string> auctions = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString))
                {
                    conn.Open();
                    string oString = "Select * from Auction_All";
                    SqlCommand oCmd = new SqlCommand(oString, conn);
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            auctions.Add(oReader["org"].ToString());
                        }
                    }
                    conn.Close();
                }
                return auctions;
            }
            catch (SqlException ex)
            {
                return auctions;
            }
        }

        public static List<string> auction_info(string auction_org)
        {
            List<string> info = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString))
                {
                    conn.Open();
                    string oString = "Select * from Auction_All where org = " + "'" + auction_org + "'";
                    SqlCommand oCmd = new SqlCommand(oString, conn);
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            info.Add(oReader["org"].ToString());
                            info.Add(oReader["contact"].ToString());
                            info.Add(oReader["date_time"].ToString());
                            info.Add(oReader["intake"].ToString());
                            info.Add(oReader["exp_num_items"].ToString());
                            info.Add(oReader["comments"].ToString());
                        }
                    }
                    conn.Close();
                }
                return info;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                return info;
            }
        }
        public static List<string> auction_on_date(string date)
        {
            List<string> auctions = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString))
                {
                    conn.Open();
                    string oString = "Select org from Auction_All where date_time between " + "'" + date + " 00:00:00' and " + "'" + date + " 23:59:59'";
                    SqlCommand oCmd = new SqlCommand(oString, conn);
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            auctions.Add(oReader["org"].ToString());
                        }
                    }
                    conn.Close();
                }
                return auctions;
            }
            catch (SqlException ex)
            {
                return auctions;
            }
        }
        public static void login(string account_email, string account_password)
        {
            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    string oString = "";
                    SqlCommand cmd = new SqlCommand(@"select * from User_All where account_email = @account_email 
                        and account_password = @account_password", con);
                    cmd.Parameters.AddWithValue("@account_email", account_email);
                    cmd.Parameters.AddWithValue("@account_password", account_password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                Debug.WriteLine("here");
                                if (reader["account_type"].ToString() == "bidder")
                                {
                                    HttpContext.Current.Session["account_type"] = "bidder";
                                    oString = "select * from Bidder_All where account_email = @account_email";
                                }

                                if (reader["account_type"].ToString() == "employee")
                                {
                                    HttpContext.Current.Session["account_type"] = "employee";
                                    oString = "select * from Employee_All where account_email = @account_email";
                                }

                                if (reader["account_type"].ToString() == "npo_rep")
                                {
                                    HttpContext.Current.Session["account_type"] = "npo_rep";
                                    oString = "select * from NPO_Rep_All where account_email = @account_email";
                                }
                            }
                        }
                    }
                    SqlCommand oCmd = new SqlCommand(oString, con);
                    oCmd.Parameters.AddWithValue("@account_email", account_email);
                    if (oString.Length > 1)
                    {
                        using (SqlDataReader oReader = oCmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                HttpContext.Current.Session["account_email"] = oReader["account_email"].ToString();
                                HttpContext.Current.Session["full_name"] = oReader["full_name"].ToString();
                                HttpContext.Current.Session["phone"] = oReader["phone"].ToString();
                                if ((string)HttpContext.Current.Session["account_type"] == "bidder")
                                {
                                    HttpContext.Current.Session["street"] = oReader["street"].ToString();
                                    HttpContext.Current.Session["city"] = oReader["city"].ToString();
                                    HttpContext.Current.Session["us_state"] = oReader["us_state"].ToString();
                                    HttpContext.Current.Session["zip"] = oReader["zip"].ToString();
                                }
                                if ((string)HttpContext.Current.Session["account_type"] != "employee")
                                {
                                    HttpContext.Current.Session["phone"] = oReader["phone"].ToString();
                                }
                                HttpContext.Current.Session["loggedIn"] = "true";
                            }
                        }
                        HttpContext.Current.Response.Redirect("~/Main.aspx");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }

        public static void register_employee(string account_email, string account_password, string full_name)
        {
            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into Employee_All_View values (@account_email,
                        @account_password, @full_name)", con);
                    cmd.Parameters.AddWithValue("@account_email", account_email);
                    cmd.Parameters.AddWithValue("@account_password", encrypt.encryptPass(account_password));
                    cmd.Parameters.AddWithValue("@full_name", full_name);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

        }

        public static void register_npo_rep(string account_email, string account_password, string full_name, string phone)
        {
            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into NPO_Rep_All_View values (@account_email,
                        @account_password, @full_name, @phone)", con);
                    cmd.Parameters.AddWithValue("@account_email", account_email);
                    cmd.Parameters.AddWithValue("@account_password", encrypt.encryptPass(account_password));
                    cmd.Parameters.AddWithValue("@full_name", full_name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public static void register_bidder(string account_email, string account_password, string full_name, string phone,
            string street, string city, string us_state, string zip)
        {
            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into Bidder_All_View values (@account_email,
                        @account_password, @full_name, @phone, @street, @city, @us_state, @zip)", con);
                    cmd.Parameters.AddWithValue("@account_email", account_email);
                    cmd.Parameters.AddWithValue("@account_password", encrypt.encryptPass(account_password));
                    cmd.Parameters.AddWithValue("@full_name", full_name);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@us_state", us_state);
                    cmd.Parameters.AddWithValue("@zip", zip);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public static List<string[]> all_items()
        {
            List<string[]> items = new List<string[]>();

            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select auction, item_name, id from Item_All", con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                string[] item = new string[3];
                                item[0] = reader["auction"].ToString();
                                item[1] = reader["item_name"].ToString();
                                item[2] = reader["id"].ToString();
                                items.Add(item);
                            }
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return items;
        }

        public static List<string> auction_items(string org)
        {
            List<string> items = new List<string>();

            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select item_name from Item_All where auction = @auction", con);
                    cmd.Parameters.AddWithValue("@auction", org);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                items.Add(reader["item_name"].ToString());
                            }
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return items;
        }

        public static List<string> item_info(string id)
        {
            List<string> item_info = new List<string>();

            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Item_All where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                item_info.Add(reader["item_name"].ToString());
                                item_info.Add(reader["auction"].ToString());
                                item_info.Add(reader["id"].ToString());
                                item_info.Add(reader["quantity"].ToString());
                                item_info.Add(reader["start_bid"].ToString());
                                item_info.Add(reader["donor"].ToString());
                                item_info.Add(reader["sell_price"].ToString());
                                item_info.Add(reader["condition"].ToString());
                                item_info.Add(reader["comments"].ToString());
                                item_info.Add(reader["photo"].ToString());
                            }
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return item_info;
        }

        public static string[] item_bid_info(string item_name, string org)
        {
            int id = 0;
            string[] item_bid_info = new string[2];

            string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            { 
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"select id from Item_All where item_name = @item_name
                        and auction = @auction", con);
                    cmd.Parameters.AddWithValue("@item_name", item_name);
                    cmd.Parameters.AddWithValue("@auction", org);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() && reader.HasRows)
                        {
                            id = Int32.Parse(reader["id"].ToString());
                        }
                    }
                    //con.Close();

                    //con.Open();
                    cmd = new SqlCommand(@"select Item_All.start_bid, Bid_Max.bid as highest_bid from Item_All, 
                        (select max(bid) as bid from Bid group by item having item = id) as Bid_Max 
                        where Item_All.id = id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                item_bid_info[0] = reader["start_bid"].ToString();
                                item_bid_info[1] = reader["highest_bid"].ToString();
                            }
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return item_bid_info;
        }
    }
}
//update user with session variables
