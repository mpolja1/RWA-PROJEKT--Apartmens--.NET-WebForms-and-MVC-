using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TaggedApartment
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int ApartmentId { get; set; }
        public Tag Tag { get; set; }
    }
}
