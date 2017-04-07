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
            name = (string)Session["firstname"];
            email = (string)Session["email"];
            phone = (string)Session["phone"];
            street = (string)Session["street"];
            city = (string)Session["city"];
            state = (string)Session["state"];
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
            else
                showEditProfile();
            
                
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
                showCurrentProfile();
            else if (editProfSubmit.Text.ToString().Equals("Edit"))
                showEditProfile();
            else if (editProfSubmit.Text.ToString().Equals("Register"))
                Response.Redirect("~/login.aspx");
        }

        public void showEditProfile()
        {

            editLabel.Text = "  Edit Profile  ";
            nameInput.Visible = true;
            nameInput.Text = name;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = true;
            emailInput.Text = email;
            emailILabel.Text ="Email:";
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

            nameInput.Visible = false;
            nameInputLabel.Text = nameInputLabel.Text.ToString() + name;
            emailInput.Visible = false;
            emailILabel.Text = emailILabel.Text.ToString() + email;
            phoneInput.Visible = false;
            phoneLabel.Text = phoneLabel.Text.ToString() + phone;
            addressLabel.Text = addressLabel.Text.ToString() + address;
            streetInput.Visible = false;
            streetAdLabel.Text = streetAdLabel.Text.ToString() + street;
            cityInput.Visible = false;
            cityLabel.Text = cityLabel.Text.ToString() + city;
            stateInput.Visible = false;
            stateLabel.Text = stateLabel.Text.ToString() + state;
            zipInput.Visible = false;
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