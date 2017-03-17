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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void editProfSubmit_Click(object sender, EventArgs e)
        {
            name = nameInput.Text;
            Response.Redirect("~/SelectAuction.aspx");
        }
    }
}