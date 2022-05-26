using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Phone-Number")]
        public string PhoneNumber { get; set; }

       
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }

       
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

    }
}
