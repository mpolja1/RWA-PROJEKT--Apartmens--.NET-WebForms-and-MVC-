using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                if (username == "admin" && password=="123")
                {

                    Session["name"] = txtUsername.Text;
                    Session["password"] = txtPassword.Text;
                    Response.Redirect("Apartmants.aspx");
                }
                else
                {
                    PanelIspis.Visible = true;
                }
            }
            
        }
    }
}