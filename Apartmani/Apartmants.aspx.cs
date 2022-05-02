using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Apartmants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblFName.Text = (string)Session["name"];
                lblLName.Text = (string)Session["password"];
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }
    }
}