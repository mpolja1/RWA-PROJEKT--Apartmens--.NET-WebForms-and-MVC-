using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani_publicccc.Models
{
    public class ApartmentDetailsViewModel
    {
        public Apartment apartment { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<ApartmentPicture> Images { get; set; }
    }
}