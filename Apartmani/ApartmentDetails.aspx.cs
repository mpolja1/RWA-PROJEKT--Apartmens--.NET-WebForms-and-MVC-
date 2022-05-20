using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class ApartmentDetails : System.Web.UI.Page
    {
         private Apartment _apartment;
        private IList<TaggedApartment> _apartmentTaggs;
        private IList<ApartmentPicture> _pictures;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["IdApartment"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            try
            {
                
                
                    int id = (int)Session["IdApartment"];
                    _apartment = ((Irepo)Application["database"]).GetApartmentById(id);
                _apartmentTaggs = ((Irepo)Application["database"]).GetTagsByApartment(id);
                _pictures = ((Irepo)Application["database"]).GetApartmentPictures(id);




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

           
            if (!IsPostBack)
            {
                AppendApartmentTaggs();

                AppendStatus();
                AppendCity();
                AppendImages();
                AppendApartment();
                DoReadOnly(this.PanelEditApartment);
            }         

        }

        private void AppendImages()
        {
            RepeaterImages.DataSource = _pictures;
            RepeaterImages.DataBind();
        }

        private void AppendApartmentTaggs()
        {
            RepeaterTags.DataSource=_apartmentTaggs;
            RepeaterTags.DataBind();
        }

        private void AppendStatus()
        {
           ddlStatusAdd.DataSource= ((Irepo)Application["database"]).GetApartmentStatus();
            ddlStatusAdd.DataValueField = "Id";
            ddlStatusAdd.DataTextField = "Name";
            ddlStatusAdd.DataBind();
           
        }
        private void AppendCity()
        {


            ddlCityAdd.DataSource = ((Irepo)Application["database"]).GetCities();
            ddlCityAdd.DataValueField = "Id";
            ddlCityAdd.DataTextField = "Name";
            ddlCityAdd.DataBind();
            //ddlCityAdd.Items.Insert(0, new ListItem("Any"));
        }

        private void AppendApartment()
        {
           
            
            txtOwnerName.Text = _apartment.Owner.Name;
            
            ddlCityAdd.SelectedValue = _apartment.City.Id.ToString();
            ddlStatusAdd.SelectedValue = _apartment.Status.Id.ToString();
            txtAddress.Text = _apartment.Address;
            txtName.Text = _apartment.Name;
            txtNameEng.Text = _apartment.NameEng;
            txtPrice.Text = _apartment.Price.ToString();
            txtMaxAdults.Text = _apartment.MaxAdults.ToString();
            txtMaxChildren.Text = _apartment.MaxChildren.ToString();
            txtTotalRooms.Text = _apartment.TotalRooms.ToString();
            txtBeachDistance.Text = _apartment.BeachDistance.ToString();

            if (ddlStatusAdd.SelectedItem.Text == "Rezervirano" || ddlStatusAdd.SelectedItem.Text == "Zauzeto")
            {
                btnAddReservation.Visible = true;
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            DoReadOnly(this.PanelEditApartment);
            btnEdit.Text = btnEdit.Text== "Save" ? "Edit" : "Save";
            

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

                Apartment apartment = new Apartment(_apartment.Id,apartmentOwner, apartmantStatus, city, address, apartmentName, apartmentNameEng, price, maxAdults, maxChildren, totalRooms, beachDistance);
                ((Irepo)Application["database"]).UpdateApartment(apartment);
               
            }
            
        }
        
        void DoReadOnly(Control control)
        {
            
            foreach (Control c in control.Controls)
            {
                if (c.Controls != null && c.Controls.Count > 0)
                {
                    DoReadOnly(c);
                }
                else if (c is TextBox )
                {
                    if ((c as TextBox).ReadOnly==false )
                    {
                        (c as TextBox).ReadOnly = true;
                       


                    }
                    else
                    {
                        (c as TextBox).ReadOnly=false;
                       
                    }
                }
                
            }
        }

        protected void btnAddReservation_Click(object sender, EventArgs e)
        {
           
            PanelReservation.Visible = true;
            if (Page.IsValid && !string.IsNullOrEmpty(txtReservationDetails.Text))
            {
                string details = txtReservationDetails.Text;
                string userName = txtReservationUserName.Text;
                string userEmail = txtReservationUserEmail.Text;
                string userPhone = txtReservationUserPhone.Text;
                string userAdress = txtReservationUserAdress.Text;

                ApartmentReservation apartmentReservation = new ApartmentReservation(details, userName, userEmail, userPhone, userAdress);


                try
                {
                    ((Irepo)Application["database"]).SaveApartmentReservation(_apartment.Id, apartmentReservation);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            ClearForm();


            
        }

        private void ClearForm()
        {
            txtReservationDetails.Text="";
            txtReservationUserName.Text="";
            txtReservationUserEmail.Text="";
            txtReservationUserPhone.Text="";
             txtReservationUserAdress.Text="";
          
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
         
            if (ImageUpload.HasFile)
            {
                
                string imgfile= Path.GetFileName(ImageUpload.FileName);
                string path = Path.Combine(Server.MapPath("Images/"), imgfile);
                ImageUpload.SaveAs(path);
                string databasePath = "~/Images/" + imgfile;
     

                   
                    int idApart = (int)Session["IdApartment"];
                    string title = txtImageName.Text;
                    ApartmentPicture apartmentPicture = new ApartmentPicture(idApart, databasePath, title);
                    ((Irepo)Application["database"]).SaveApartmentImages(apartmentPicture);
                lblMsg.Text = "Uspjesno spremljeno";
                lblMsg.ForeColor = System.Drawing.Color.Green;


            }
            else
            {
                lblMsg.Text = "Greska";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            
        }
    }
}