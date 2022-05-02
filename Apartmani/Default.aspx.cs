using DAL;
using DAL.Models;
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
            if (Session["employee"] != null)
            {
                Response.Redirect("Apartmants.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

               
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                Employee employee = ((Irepo)Application["database"]).AuthEmployee(username,password);
                
                if (employee == null)
                {

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    PanelIspis.Visible = true;
                }
                else
                {
                    Session["employee"] = employee;
                    Response.Redirect("Apartmants.aspx");
                }
            }
            
        }
    }
}