using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace auction_proj
{
    public class dbClass
    {
        public static String query(string select, string from, string where)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT @sstring FROM @fstring 
                                        WHERE @wstring", con);
            cmd.Parameters.AddWithValue("@sstring", select);
            cmd.Parameters.AddWithValue("@fstring", from);
            cmd.Parameters.AddWithValue("@wstring", where);
            string temp= (string)cmd.ExecuteScalar();
            con.Close();
            return temp;
        }
    }
}