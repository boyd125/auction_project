using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class BidderEditProfile : System.Web.UI.Page
    {
        public static int whatToDo = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            nameInput.Text = (string)Session["full_name"];
            phoneInput.Text = (string)Session["phone"];
            streetInput.Text = (string)Session["street"];
            stateInput.Text = (string)Session["us_state"];
            zipInput.Text = (string)Session["zip"];
            */
            if (whatToDo != 2)
            {
                if ((string)Session["loggedIn"] == "false")
                {
                    Response.Redirect("~/login.aspx");
                }
            }

            if (whatToDo == 0)
            {
                showCurrentProfile();
            }
            else if (whatToDo == 1)
            {
                showEditProfile();
            }
            else if (whatToDo == 2)
            {
                showRegProfile();
            }


        }
        public static void whatChoice(int choice)
        {
            //if current 0
            //if edit 1
            //if register 2
            BidderEditProfile.whatToDo = choice;
        }

        protected void editProfSubmit_Click(object sender, EventArgs e)
        {
            if (editProfSubmit.Text.ToString().Equals("Submit"))
            {                
                //dbClass.update();
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Bidder_All SET full_name=@name, phone=@phone, street=@street, city=@city, us_state=@state, zip = @zip" + " WHERE account_email=@Id", conn))
                        {
                            Session["full_name"] = nameInput.Text;
                            Session["phone"] = phoneInput.Text;
                            Session["street"] = streetInput.Text;
                            Session["city"] = cityInput.Text;
                            Session["us_state"] = stateInput.Text;
                            Session["zip"] = zipInput.Text;
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
                        whatToDo = 0;
                        Response.Redirect("~/BidderEditProfile.aspx");
                    }
                }
                catch (SqlException ex)
                {
                    editLabel.Text = "Not all valid values. Please try again";
                }
                //TODO record the data
            }
            //want to edit profile 
            else if (editProfSubmit.Text.ToString().Equals("Edit"))
            {
                whatToDo = 1;
                Response.Redirect("~/BidderEditProfile.aspx");
            }
            //just entered register info  
            else if (editProfSubmit.Text.ToString().Equals("Register"))
            {
                string conStr = ConfigurationManager.ConnectionStrings["masterDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO Bidder_All (account_email, account_password, full_name, phone, street, city, us_state, zip) VALUES (@email, @pass, @fname, @phone, @street, @city, @us_state, @zip)", con);
                        cmd.Parameters.AddWithValue("@email", emailInput.Text);
                        cmd.Parameters.AddWithValue("@pass", encrypt.encryptPass(passTB.Text));
                        cmd.Parameters.AddWithValue("@fname", nameInput.Text);
                        cmd.Parameters.AddWithValue("@phone", phoneInput.Text);
                        cmd.Parameters.AddWithValue("@street", streetInput.Text);
                        cmd.Parameters.AddWithValue("@city", cityInput.Text);
                        cmd.Parameters.AddWithValue("@us_state", stateInput.Text);
                        cmd.Parameters.AddWithValue("@zip", zipInput.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("~/login.aspx");
                    }
                    catch (Exception ex)
                    {
                        editLabel.Text = ("Unexpected error:" + ex.Message);
                    }
                }
                //TODO record data
            }               
        }

        public void showEditProfile()
        {
            editLabel.Text = "  Edit Profile  ";
            nameInput.Visible = true;
            //nameInput.Text = name;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = false;
            //emailInput.Text = email;
            emailILabel.Text ="Email:   " + (string)Session["account_email"];
            phoneInput.Visible = true;
            //phoneInput.Text = phone;
            phoneLabel.Text ="Phone #:";
            addressLabel.Text = "Address:";
            streetInput.Visible = true;
            //streetInput.Text = street;
            streetAdLabel.Text = "Street:";
            cityInput.Visible = true;
            //cityInput.Text = city;
            cityLabel.Text = "City:";
            stateInput.Visible = true;
            //stateInput.Text = state;
            stateLabel.Text = "State:";
            zipInput.Visible = true;
            //zipInput.Text = zip;
            zipLabel.Text = "Zip:";

            editProfSubmit.Text = "Submit";
        }
        public void showCurrentProfile()
        {
            editLabel.Text = "  Current Profile  ";
            //name = nameInput.Text.ToString();
            nameInput.Visible = false;
            nameInputLabel.Text = nameInputLabel.Text.ToString() + (string)Session["full_name"];
            emailInput.Visible = false;
            //email = emailInput.Text.ToString();
            emailILabel.Text = emailILabel.Text.ToString() + (string)Session["account_email"];
            phoneInput.Visible = false;
            //phone = phoneInput.Text.ToString();
            phoneLabel.Text = phoneLabel.Text.ToString() + (string)Session["phone"];
            addressLabel.Text = addressLabel.Text.ToString() + (string)Session["street"];
            streetInput.Visible = false;
            //street = streetInput.Text.ToString();
            cityInput.Visible = false;
            //city = cityInput.Text.ToString();
            stateInput.Visible = false;
            //state = stateInput.Text.ToString();
            stateLabel.Text = stateLabel.Text.ToString() + (string)Session["us_state"];
            zipInput.Visible = false;
            //zip = zipInput.Text.ToString();
            zipLabel.Text = zipLabel.Text.ToString() + (string)Session["zip"];

            editProfSubmit.Text = "Edit";
        }

        public void showRegProfile()
        {
            editLabel.Text = "  New Profile  ";

            userLabel.Visible = true;
            userTB.Visible = true;
            passLabel.Visible = true;
            passTB.Visible = true;
            passConfirmLabel.Visible = true;
            confirmTB.Visible = true;

            nameInput.Visible = true;
            //nameInput.Text = name;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = true;
            emailILabel.Text = "Email:";
            phoneInput.Visible = true;
            phoneLabel.Text = "Phone #:";
            addressLabel.Text = "Address:";
            streetInput.Visible = true;
            streetAdLabel.Text = "Street:";
            cityInput.Visible = true;
            cityLabel.Text = "City:";
            stateInput.Visible = true;
            stateLabel.Text = "State:";
            zipInput.Visible = true;
            zipLabel.Text = "Zip:";

            editProfSubmit.Text = "Register";
            backToHome.Visible = false;

        }

        protected void backToHome_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Main.aspx");
        }
    }
}