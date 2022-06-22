using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApartmentReservation
    {
     

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }

        public ApartmentReservation(string details, string userName, string userEmail, string userPhone, string userAddress, int apartmentId)
        {
            Details = details;
            UserName = userName;
            UserEmail = userEmail;
            UserPhone = userPhone;
            UserAddress = userAddress;
            ApartmentId = apartmentId;
        }
        public ApartmentReservation()
        {

        }
    }
}
