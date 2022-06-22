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
        private List<City> _listofCities;
        private List<ApartmantStatus> _listofApartmentStauts;
        private List<Apartment> _listofApartments;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            Employee em = (Employee)Session["employee"];
            if (em == null)
            {
                Response.Redirect("Default.aspx");
            }

            try
            {

                _listofCities = ((Irepo)Application["database"]).GetCities();
                _listofApartments = ((Irepo)Application["database"]).GetApartments();
                _listofApartmentStauts = ((Irepo)Application["database"]).GetApartmentStatus();
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (!IsPostBack)
            {

                AppendStatus();
                AppendCity();
               
                AppendApartments();
               
            }

           


        }

        private void AppendApartments()
        {
            _listofApartments = ((Irepo)Application["database"]).GetApartments();
            
            RepeaterApartments.DataSource = _listofApartments;
            RepeaterApartments.DataBind();

        }

      

        private void AppendCity()
        {
            

            ddlCity.DataSource = _listofCities;
            ddlCity.DataValueField = "Id";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();
            //ddlCity.Items.Insert(0, new ListItem("Any"));
        }

        private void AppendStatus()
        {
            ddlStatus.DataSource = _listofApartmentStauts;
            ddlStatus.DataValueField = "Id";
            ddlStatus.DataTextField = "Name";
            ddlStatus.DataBind();
        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //}



        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Apartment> _listofApartmentsByCity = new List<Apartment>();

            DropDownList ddl = sender as DropDownList;

            if (ddl.SelectedIndex != 0)
            {
                int selectedCity = Convert.ToInt32(ddlCity.SelectedValue);
                int selectedStatus = int.Parse(ddlStatus.SelectedValue);

                

                _listofApartmentsByCity = _listofApartments.Where(x => x.City.Id == selectedCity /*&& x.Status.Id == selectedStatus*/).ToList();

                RepeaterApartments.DataSource = _listofApartmentsByCity;
                RepeaterApartments.DataBind();
                
            }

            
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Apartment> apartmentsbystatus = new List<Apartment>();

            
            int selectedStatus = int.Parse(ddlStatus.SelectedValue);
            if (ddlCity.SelectedIndex != 0)
            {
                int selectedCity = int.Parse(ddlCity.SelectedValue);
               
                
                apartmentsbystatus = _listofApartments.Where(x => x.City.Id == selectedCity && x.Status.Id == selectedStatus).ToList();
            }
            else
            {
                apartmentsbystatus = _listofApartments.Where(x =>  x.Status.Id == selectedStatus).ToList();
            }

            


            //indexx.Text = /*selectedCity +*/ "=city  " + selectedStatus + "=status";
                RepeaterApartments.DataSource = apartmentsbystatus;
                RepeaterApartments.DataBind();
            
           
        }

        private void RefreshData(List<Apartment> listofApartments)
        {
            RepeaterApartments.DataSource = listofApartments;
            RepeaterApartments.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {



            AppendCityInForm();
            AppendStatusInForm();

            PanelApartment.Visible = true;


        }

        private void AppendStatusInForm()
        {
            ddlStatusAdd.DataSource = ((Irepo)Application["database"]).GetApartmentStatus();
            ddlStatusAdd.DataValueField = "Id";
            ddlStatusAdd.DataTextField = "Name";
            ddlStatusAdd.DataBind();
        }

        private void AppendCityInForm()
        {
           ddlCityAdd.DataSource = ((Irepo)Application["database"]).GetCities();
            ddlCityAdd.DataValueField = "Id";
            ddlCityAdd.DataTextField = "Name";
            ddlCityAdd.DataBind();
        }

        protected void btnSaveApartment(object sender, EventArgs e)
        {

            
                ApartmentOwner apartmentOwner = new ApartmentOwner();
                ApartmantStatus apartmantStatus = new ApartmantStatus();
                City city = new City();

                if (Page.IsValid)
                {
                    apartmentOwner.Name = txtOwnerName.Text;
                    apartmantStatus.Id = int.Parse(ddlStatusAdd.SelectedValue);
                    city.Id = int.Parse(ddlCityAdd.SelectedValue);
                    string address = txtAddress.Text;
                    string apartmentName = txtName.Text;
                    string apartmentNameEng = txtNameEng.Text;
                    decimal price = decimal.Parse(txtPrice.Text);
                    int maxAdults = int.Parse(txtMaxAdults.Text);
                    int maxChildren = int.Parse(txtMaxChildren.Text);
                    int totalRooms = int.Parse(txtTotalRooms.Text);
                    int beachDistance = int.Parse(txtBeachDistance.Text);

                    Apartment apartment = new Apartment(apartmentOwner, apartmantStatus, city, address, apartmentName, apartmentNameEng, price, maxAdults, maxChildren, totalRooms, beachDistance);
                    ((Irepo)Application["database"]).SaveApartment(apartment);

                Response.Redirect(Request.Url.LocalPath);
            }

            

        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int id = int.Parse(btn.CommandArgument);

            Session["IdApartment"]= id;

            Response.Redirect("ApartmentDetails.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int id = int.Parse(btn.CommandArgument);
            ((Irepo)Application["database"]).DeleteApartmentSoft(id);
            AppendApartments();
        }

        public bool IsRepresentative(int myValue)
        {
            if (myValue == 1)
            {
                return true;
            }
            return false;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            PanelApartment.Visible = false;
        }
    }
}