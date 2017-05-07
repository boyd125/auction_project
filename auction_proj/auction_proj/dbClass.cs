﻿using System;
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
                    string oString = "Select * from Auction_All where org = "+ "'" + auction_org + "'";
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
                    cmd.Parameters.AddWithValue("@account_password", encrypt.encryptPass(account_password));
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
                                HttpContext.Current.Session["loggedIn"]="true";
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
    }
}
//update user with session variables
