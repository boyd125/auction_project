﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace auction_proj
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void submitToDo_Click(object sender, EventArgs e)
        {
            int idx = toDoDropDown.SelectedIndex;
            switch(idx)
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
                    SelectAuction.setMyOrBrowseAuctions(1);
                    Response.Redirect("~/SelectAuction.aspx");
                    break;
                //view calander
                case 3:
                    Response.Redirect("~/AuctionCalendar.aspx");                    
                    break;
                //my profile
                case 4:
                    Response.Redirect("~/BidderEditProfile.aspx");
                    break;
                
               
            }
            
            
        }
    }
}