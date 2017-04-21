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


        }
    }
}