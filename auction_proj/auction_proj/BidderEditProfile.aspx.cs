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
        public static String name;
        public static String email;
        public static String phone;
        public static String address;
        public static String street;
        public static String city;
        public static String state;
        public static String zip;

        public static int whatToDo = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(whatToDo != 2)
            {
                if ((string)Session["loggedIn"] == "false")
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            
            name = (string)Session["full_name"];
            email = (string)Session["account_email"];
            phone = (string)Session["phone"];
            street = (string)Session["street"];
            city = (string)Session["city"];
            state = (string)Session["us_state"];
            zip = (string)Session["zip"];

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
            //just edited profile
            if (editProfSubmit.Text.ToString().Equals("Submit"))
            {
                //TODO record the data
                whatToDo = 0;
                Response.Redirect("~/BidderEditProfile.aspx");
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
                //TODO record data
                Response.Redirect("~/login.aspx");
            }
                
        }

        public void showEditProfile()
        {

            editLabel.Text = "  Edit Profile  ";
            nameInput.Visible = true;
            nameInput.Text = name;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = false;
            //emailInput.Text = email;
            emailILabel.Text ="Email:" + email;
            phoneInput.Visible = true;
            phoneInput.Text = phone;
            phoneLabel.Text ="Phone #:";
            addressLabel.Text = "Address:";
            streetInput.Visible = true;
            streetInput.Text = street;
            streetAdLabel.Text = "Street:";
            cityInput.Visible = true;
            cityInput.Text = city;
            cityLabel.Text = "City:";
            stateInput.Visible = true;
            stateInput.Text = state;
            stateLabel.Text = "State:";
            zipInput.Visible = true;
            zipInput.Text = zip;
            zipLabel.Text = "Zip:";

            editProfSubmit.Text = "Submit";
        }
        public void showCurrentProfile()
        {
            editLabel.Text = "  Current Profile  ";
            //name = nameInput.Text.ToString();
            nameInput.Visible = false;
            nameInputLabel.Text = nameInputLabel.Text.ToString() + name;
            emailInput.Visible = false;
            //email = emailInput.Text.ToString();
            emailILabel.Text = emailILabel.Text.ToString() + email;
            phoneInput.Visible = false;
            //phone = phoneInput.Text.ToString();
            phoneLabel.Text = phoneLabel.Text.ToString() + phone;
            addressLabel.Text = addressLabel.Text.ToString() + address;
            streetInput.Visible = false;
            //street = streetInput.Text.ToString();
            streetAdLabel.Text = streetAdLabel.Text.ToString() + street;
            cityInput.Visible = false;
            //city = cityInput.Text.ToString();
            cityLabel.Text = cityLabel.Text.ToString() + city;
            stateInput.Visible = false;
            //state = stateInput.Text.ToString();
            stateLabel.Text = stateLabel.Text.ToString() + state;
            zipInput.Visible = false;
            //zip = zipInput.Text.ToString();
            zipLabel.Text = zipLabel.Text.ToString() + zip;

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
            nameInput.Text = name;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = true;
            emailInput.Text = email;
            emailILabel.Text = "Email:";
            phoneInput.Visible = true;
            phoneInput.Text = phone;
            phoneLabel.Text = "Phone #:";
            addressLabel.Text = "Address:";
            streetInput.Visible = true;
            streetInput.Text = street;
            streetAdLabel.Text = "Street:";
            cityInput.Visible = true;
            cityInput.Text = city;
            cityLabel.Text = "City:";
            stateInput.Visible = true;
            stateInput.Text = state;
            stateLabel.Text = "State:";
            zipInput.Visible = true;
            zipInput.Text = zip;
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