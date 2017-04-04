using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            name = login.username;
        }

        protected void editProfSubmit_Click(object sender, EventArgs e)
        {
            //do null check
            name = nameInput.Text.ToString();
            email = emailInput.Text.ToString();
            phone = phoneInput.Text.ToString();
            address = addressInput.Text.ToString();
            street = streetInput.Text.ToString();
            city = cityInput.Text.ToString();
            state = stateInput.Text.ToString();
            zip = zipInput.Text.ToString();

            if (editProfSubmit.Text.ToString().Equals("Submit"))
                showCurrentProfile();
            else
                showEditProfile();

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
            addressInput.Visible = true;
            addressInput.Text = address;
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
            addressInput.Visible = false;
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

        protected void backToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}