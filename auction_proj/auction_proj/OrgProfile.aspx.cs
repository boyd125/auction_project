using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class OrgProfile : System.Web.UI.Page
    {
        public static int whatToDo = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            orgNameInput.Text = "Red Cross";
            repNameInput.Text = "Joe Smith";
            repPhoneInput.Text = "(714) 999-9999";
            repEmailInput.Text = "smith@redcross.com";
            orgStreetInput.Text = "1111 E Alabama Ave.";
            orgStateInput.Text = "CA";
            orgCityInput.Text = "Los Angeles";
            orgZipInput.Text = "83043";


            //check what type of profile they want to see
            //if they want to show current profile
            //if they want to show edit profile
            //if they want to register a new profile
            if (whatToDo != 2)
            {
                if ((string)Session["loggedIn"] == "false")
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (whatToDo == 0)
                {
                    showCurrentProfile();
                }
                else if (whatToDo == 1)
                {
                    showEditProfile();
                }
                /*else if (whatToDo == 2)
                {
                    
                }*/
            }


        }
        //this will be called from other pages, to let this page know which view to load
        public static void whatChoice(int choice)
        {
            //if current 0
            //if edit 1
            //if register 2
            OrgProfile.whatToDo = choice;
        }

        protected void orgProfSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void showCurrentProfile()
        {
            //change label to current profile
            editLabel.Text = "  Current Org Profile  ";
            //hide the edit texts
            //update the information
            //attach it to the category labels
            //change the text of the button
            orgProfSubmit.Text = "Edit";
        }
        private void showEditProfile()
        {
            //change label to edit profile
            editLabel.Text = "  Edit Org Profile  ";
            //show the edit texts
            //update the labels
            //update the edit box's with the current information
            //change the text of the button
            orgProfSubmit.Text = "Submit";
        }
        private void showRegisterProfile()
        {
            //change label to register a new profile
            //add necesary text fields for passwords and other secure information
            //change the text of the button
        }

        protected void backToHome_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Main.aspx");
        }

    }
}