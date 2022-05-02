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
        private IList<City> _listofCities;
        protected void Page_Load(object sender, EventArgs e)
        {
          _listofCities =((Irepo)Application["database"]).GetCities();
            Repeater1.DataSource = _listofCities;
            Repeater1.DataBind();
        }
    }
}