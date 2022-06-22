using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani_publicccc.Models
{
    public class ApartmentReviewVM
    {
        public Apartment apartment { get; set; }
        public ApartmentReview apartmentReview { get; set; }
    }
}