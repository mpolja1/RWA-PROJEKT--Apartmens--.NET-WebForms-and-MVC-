using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public static class RepoFactory
    {
        public static Irepo GetRepository() => new DbRepo();
    }
}
