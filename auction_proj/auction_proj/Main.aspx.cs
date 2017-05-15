using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class Main : System.Web.UI.Page
    {
        //default value is nope
        String who = "nope";

        protected void Page_Load(object sender, EventArgs e)
        {
            string temp = (string)Session["loggedIn"];
            if (temp == "false")
            {
                Response.Redirect("~/login.aspx");
            }
            //check the account type and only show the proper drop down
            if((string)HttpContext.Current.Session["account_type"] == "employee" || (string)HttpContext.Current.Session["account_type"] =="npo_rep" && toDoDropDown.Items.Count<5)
            {
                toDoDropDown.Items.Add("Register Employee/Rep");
            }
            //show welcome message
            welcomeTB.Text = "Welcome, " + (string)Session["full_name"];
            who = (string)Session["account_type"];


        }

        protected void submitToDo_Click(object sender, EventArgs e)
        {
            int idx = toDoDropDown.SelectedIndex;
            switch (idx)
            {
                //nothing selected
                case 0:
                    break;
                //browse
                case 1:
                    SelectAuction.setMyOrBrowseAuctions(0);
                    Response.Redirect("~/SelectAuction.aspx");
                    break;
                //myauctions
                case 2:
                   
                    Response.Redirect("~/auctionPage.aspx");
                    break;
                //view calander
                case 3:
                    Response.Redirect("~/AuctionCalendar.aspx");
                    break;
                //my profile
                case 4:
                    if (who.Equals("bidder"))
                    {
                        BidderEditProfile.whatChoice(0);
                        Response.Redirect("~/BidderEditProfile.aspx");
                    }
                    else if (who.Equals("nope"))
                    {
                        //Show a message box that they need to select an account type
                    }
                    else if (who.Equals("npo_rep"))
                    {
                        OrgProfile.whatChoice(0);
                        Response.Redirect("~/OrgProfile.aspx");
                    }
                    else if (who.Equals("employee"))
                    {
                        BidderEditProfile.whatChoice(0);
                        Response.Redirect("~/BidderEditProfile.aspx");
                    }
                        

                    break;
                case 5:
                    Response.Redirect("~/empReg.aspx");
                    break;
            }
            
            
        }
    }
}