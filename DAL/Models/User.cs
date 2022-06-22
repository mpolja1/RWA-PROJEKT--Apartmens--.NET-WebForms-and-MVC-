using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.Resources;
using Microsoft.AspNet.Identity;

namespace DAL.Models
{
    public class User : IUser
    {
        //public int Id { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Required(ErrorMessageResourceType =typeof(Language),ErrorMessageResourceName = "RequiredField")]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessageResourceType = typeof(Language), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        [Required(ErrorMessageResourceType = typeof(Language), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Phone-Number")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
       
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Language), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Language), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }


        
    }
}
