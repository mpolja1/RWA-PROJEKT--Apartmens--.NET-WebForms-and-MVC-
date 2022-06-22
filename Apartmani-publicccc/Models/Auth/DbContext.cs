using DAL;
using DAL.DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani_publicccc.Models.Auth
{
    
    public  class DbContext : IDisposable
    {

       static Irepo _repo = RepoFactory.GetRepository();
        public IList<User> Users { get; set; }
        public  DbContext(IList<User> users)
        {
            Users = users;
        }
        public void Dispose()
        {
           
        }

        public static DbContext Create()
        {

            var users = _repo.GetUsers();

            return new DbContext(users);
        }
      
            
    }
}