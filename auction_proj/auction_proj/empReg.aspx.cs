using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace auction_proj
{
    public partial class empReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedIn"] == "false")
            {
                //Response.Redirect("~/login.aspx");
            }

        }
        protected void editProfSubmit_Click(object sender, EventArgs e)
        {
            //shows edit profile for employee or npo rep
                accountSelect.Visible = true;
                string acc="";
                if (accountSelect.SelectedIndex == 0)
                {
                    acc = "npo_rep";
                    phoneInput.Visible = true;
                }
                if (accountSelect.SelectedIndex == 1)
                {
                    acc = "employee";
                    phoneInput.Visible = false;
                }   
                string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
                if(acc=="npo_rep")
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO NPO_Rep_All (account_email, account_password, full_name, phone) VALUES (@email, @pass, @fname, @phone)", con);
                            cmd.Parameters.AddWithValue("@email", emailInput.Text);
                            cmd.Parameters.AddWithValue("@pass", encrypt.encryptPass(passTB.Text));
                            cmd.Parameters.AddWithValue("@fname", nameInput.Text);
                            cmd.Parameters.AddWithValue("@phone", phoneInput.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("~/main.aspx");
                        }
                        catch (Exception ex)
                        {
                            editLabel.Text = ("Unexpected error:" + ex.Message);
                        }
                    }
                }
                if (acc == "employee")
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO Employee_All (account_email, account_password, full_name) VALUES (@email, @pass, @fname)", con);
                            cmd.Parameters.AddWithValue("@email", emailInput.Text);
                            cmd.Parameters.AddWithValue("@pass", encrypt.encryptPass(passTB.Text));
                            cmd.Parameters.AddWithValue("@fname", nameInput.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Redirect("~/Main.aspx");
                        }
                        catch (Exception ex)
                        {
                            editLabel.Text = ("Unexpected error:" + ex.Message);
                        }
                    }
                
                
            }
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine(nameInput.Text.ToString());
            Response.Redirect("~/Main.aspx");
        }

        protected void accountSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountSelect.SelectedIndex == 0)
            {
                phoneInput.Visible=true;
            }
            if (accountSelect.SelectedIndex == 1)
            {
                phoneInput.Visible = false;
            }
        }
    }
}