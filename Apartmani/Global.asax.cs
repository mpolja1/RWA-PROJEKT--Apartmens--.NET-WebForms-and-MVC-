using DAL;
using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Apartmani
{
    public class Global : System.Web.HttpApplication
    {
        private readonly Irepo _repo;

        public Global()
        {
            _repo = RepoFactory.GetRepository();
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = _repo;
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

    }
}