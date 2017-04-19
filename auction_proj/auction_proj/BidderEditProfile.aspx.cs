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
        string name, phone, street, state, city, zip;
        public static int whatToDo = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (whatToDo != 2)
            {
                if ((string)Session["loggedIn"] == "false")
                {
                    Response.Redirect("~/login.aspx");
                }
            }

           
            name = (string) Session["full_name"];
            phone = (string)Session["phone"];
            street = (string)Session["street"];
            state = (string)Session["us_state"];
            city = (string)Session["city"];
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
            if (editProfSubmit.Text.ToString().Equals("Submit"))
            {                
                Session["full_name"] = nameInput.Text;
                Session["phone"] = phoneInput.Text;
                Session["street"] = streetInput.Text;
                Session["us_state"] = stateInput.Text;
                Session["city"] = cityInput.Text;
                Session["zip"] = zipInput.Text;
                dbClass.update();
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
            nameInput.Text = this.name;
            nameInput.Visible = true;
            nameInputLabel.Text = "Name:";
            emailInput.Visible = false;
            emailILabel.Text ="Email:   " + (string)Session["account_email"];
            phoneInput.Text = this.phone;
            phoneInput.Visible = true;
            phoneLabel.Text ="Phone #:";
            addressLabel.Text = "Address:";
            streetInput.Text = this.street;
            streetInput.Visible = true;
            streetAdLabel.Text = "Street:";
            cityInput.Text = this.city;
            cityInput.Visible = true;
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
           
            emailILabel.Text = emailILabel.Text.ToString() + (string)Session["account_email"];
            phoneInput.Visible = false;
           
            phoneLabel.Text = phoneLabel.Text.ToString() + phone;
            addressLabel.Text = addressLabel.Text.ToString();
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