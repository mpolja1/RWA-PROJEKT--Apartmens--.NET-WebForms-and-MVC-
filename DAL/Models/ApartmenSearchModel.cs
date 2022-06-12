using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApartmenSearchModel
    {
        public int? Room { get; set; }
        public int? Adult { get; set; }
        public int? Children { get; set; }

        public string Sort { get; set; }
        public int? City { get; set; }

        public string Search { get; set; }
    }
}
