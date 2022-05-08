using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apartmani
{
    public partial class RegistredUsers : System.Web.UI.Page
    {
        private IList<User> _users;
        protected void Page_Load(object sender, EventArgs e)
        {
            _users = ((Irepo)Application["database"]).GetUsers();
            if (!IsPostBack)
            {
                AppendUsers();
            }
        }

        private void AppendUsers()
        {
            RepeaterUsers.DataSource = _users;
            RepeaterUsers.DataBind();
        }
    }
}