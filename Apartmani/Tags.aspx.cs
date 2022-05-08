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
    public partial class Tags : System.Web.UI.Page
    {
        private IList<Tag> _tagcounts;
        private IList<TagType> _tagtypes;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _tagcounts = ((Irepo)Application["database"]).GetTagCount();
            _tagtypes = ((Irepo)Application["database"]).GetTagTypes();

            if (!IsPostBack)
            {
                AppendTags();
                AppendTagType();
            }
               
        }

        private void AppendTags()
        {
            _tagcounts = ((Irepo)Application["database"]).GetTagCount();
            RepeaterTags.DataSource = _tagcounts; 
            RepeaterTags.DataBind();
        }
        private void AppendTagType()
        {
            ddlType.DataSource = _tagtypes;
            ddlType.DataValueField = "Id";
            ddlType.DataTextField = "Name";
            ddlType.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            PanelAddTag.Visible = true;
            int typeId = Convert.ToInt32(ddlType.SelectedValue);
            //lblType.Text = typeId.ToString();
            string name = txtName.Text;
            string nameEng = txtNameEng.Text;
            
            if (ModelState.IsValid && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(nameEng))
            {
                Tag tag = new Tag(typeId, name, nameEng);
                ((Irepo)Application["database"]).SaveTag(tag);
                    AppendTags();
                
                
            }
           
            
        }

        protected void RepeaterTags_DeleteTag(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            
                ((Irepo)Application["database"]).DeleteTag(id);
                   AppendTags();


        }
        public bool CheckCount(int myValue)
        {
            if (myValue == 0)
            {
                return true;
            }
            return false;

        }

    }
}