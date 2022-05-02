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
    public partial class Apartmants : System.Web.UI.Page
    {
        private IList<City> _listofCities;
        private IList<ApartmantStatus> _listofApartmentStauts;
        protected void Page_Load(object sender, EventArgs e)
        {
            _listofCities = ((Irepo)Application["database"]).GetCities();
            _listofApartmentStauts = ((Irepo)Application["database"]).GetApartmentStatus();
            if (!IsPostBack)
            {
              
                AppendStatus();
                AppendCity();
                AppendSort();
            }

            Employee em = (Employee)Session["employee"];
            if (em == null)
            {
                Response.Redirect("Default.aspx");
            }
            
           
        }

        private void AppendSort()
        {
            ddlSort.Items.Add("Broj soba");
            ddlSort.Items.Add("Broj mjesta");
            ddlSort.Items.Add("Cijena");
        }

        private void AppendCity()
        {
            ddlCity.DataSource = _listofCities;
            ddlCity.DataValueField = "Id";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();
        }

        private void AppendStatus()
        {
            ddlStatus.DataSource = _listofApartmentStauts;
            ddlStatus.DataValueField = "Id";
            ddlStatus.DataTextField = "Name";
            ddlStatus.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void btnGradispis_Click(object sender, EventArgs e)
        {
            //string selectedValue = ddlCity.SelectedItem.Text;
            string selectedValue = ddlCity.SelectedValue;
            lblGrad.Text = selectedValue;
        }
    }
}