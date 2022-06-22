
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
        private IList<Tag> _apartmentTaggs;
        private IList<ApartmentPicture> _pictures;
        private int idApartment;
        private readonly string _picPath = "~/Images/";

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["IdApartment"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            try
            {

                     idApartment = (int)Session["IdApartment"];
                    _apartment = ((Irepo)Application["database"]).GetApartmentById(idApartment);
                _apartmentTaggs = ((Irepo)Application["database"]).GetTagsByApartment(idApartment);
                _pictures = ((Irepo)Application["database"]).GetApartmentPictures(idApartment);




            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

           
            if (!IsPostBack)
            {
                AppendApartmentTags();
                AppendUnusedTags();
                AppendStatus();
                AppendCity();
                AppendImages();
                AppendApartment();
                //DoReadOnly(this.PanelEditApartment);
            }         

        }

        private void AppendUnusedTags()
        {
            ddlUnusedTags.DataSource = ((Irepo)Application["database"]).GetUnusedApartmentTag(idApartment);
            ddlUnusedTags.DataValueField = "Id";
            ddlUnusedTags.DataTextField = "Name";
            ddlUnusedTags.DataBind();
        }

        private void AppendImages()
        {
            RepeaterImages.DataSource = _pictures;
            RepeaterImages.DataBind();
        }

        private void AppendApartmentTags()
        {
            ddlTags.DataSource = ((Irepo)Application["database"]).GetTagsByApartment(idApartment);
            ddlTags.DataValueField = "Id";
            ddlTags.DataTextField = "Name";
            ddlTags.DataBind();
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
            //DoReadOnly(this.PanelEditApartment);
            //btnEdit.Text = btnEdit.Text== "Save" ? "Edit" : "Save";
            

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
        
        //void DoReadOnly(Control control)
        //{
            
        //    foreach (Control c in control.Controls)
        //    {
        //        if (c.Controls != null && c.Controls.Count > 0)
        //        {
        //            DoReadOnly(c);
        //        }
        //        else if (c is TextBox )
        //        {
        //            if ((c as TextBox).ReadOnly==false )
        //            {
        //                (c as TextBox).ReadOnly = true;
                       


        //            }
        //            else
        //            {
        //                (c as TextBox).ReadOnly=false;
                       
        //            }
        //        }
                
        //    }
        //}

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

                ApartmentReservation apartmentReservation = new ApartmentReservation(details, userName, userEmail, userPhone, userAdress, _apartment.Id);


                try
                {
                    ((Irepo)Application["database"]).SaveApartmentReservation(apartmentReservation);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Uspjesna rezervacija!', '', 'success')", true);
                    PanelReservation.Visible = false;
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
                var rootImages = Server.MapPath(_picPath);
                if (!Directory.Exists(rootImages))
                {
                    Directory.CreateDirectory(rootImages);
                }
                string path = Path.Combine(rootImages, imgfile);
                ImageUpload.SaveAs(path);
                string databasePath = _picPath + imgfile;

                    int idApart = (int)Session["IdApartment"];
                    string title = txtImageName.Text;
                    ApartmentPicture apartmentPicture = new ApartmentPicture(idApart, databasePath, title);
                    ((Irepo)Application["database"]).SaveApartmentImages(apartmentPicture);
                lblMsg.Text = "Uspjesno spremljeno";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                AppendImages();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            else
            {
                lblMsg.Text = "Greska";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            //if (ImageUpload.HasFile)
            //{
            //    var imageroot = Server.MapPath(_picPath);
            //    if (!Directory.Exists(imageroot))
            //        Directory.CreateDirectory(imageroot);
            //    var imagePath = Path.Combine(imageroot, Path.GetFileName(ImageUpload.FileName));
            //    ImageUpload.SaveAs(imagePath);
            //}

        }

        protected void bntDeleteTag_click(object sender, EventArgs e)
        {
            int idTag = Convert.ToInt32(ddlTags.SelectedValue);
            ((Irepo)Application["database"]).deleteApartmentTag(idApartment,idTag);

            AppendApartmentTags();
            AppendUnusedTags();
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            int idTag = Convert.ToInt32(ddlUnusedTags.SelectedValue);

            ((Irepo)Application["database"]).AddApartmentTag(idApartment, idTag);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Uspjesno dodan tag!', '', 'success')", true);
            
            
            AppendUnusedTags();
            AppendApartmentTags();
            

        }
        

        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
           
            foreach (RepeaterItem item in RepeaterImages.Items)
            {

                CheckBox ch = item.FindControl("checkboxvalues") as CheckBox;
              int idpicture = int.Parse(ch.Attributes["CommandArgument"]);
                if (ch.Checked)
                {
                    try
                    {
                        ((Irepo)Application["database"]).DeleteApartmentPicture(idpicture);
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Uspjesno brisanje slika!', '', 'success')", true);
                    }
                    catch (Exception )
                    {

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Greska', '', 'error')", true);
                    }
                    
                }
            }
            //AppendImages();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);




        }

        protected void btnSetRepresentative_Click(object sender, EventArgs e)
        {

            foreach (RepeaterItem item in RepeaterImages.Items)
            {


                CheckBox ch = item.FindControl("checkboxvalues") as CheckBox;
                if (ch.Checked)
                {
                    int idapartmentpicture = int.Parse(ch.Attributes["CommandArgument"]);
                    ((Irepo)Application["database"]).SetRepresentativePicture(idapartmentpicture);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Uspjesno postavljena reprezentativna slika!', '', 'success')", true);
                }

                
            }
            //AppendImages();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
    }
}