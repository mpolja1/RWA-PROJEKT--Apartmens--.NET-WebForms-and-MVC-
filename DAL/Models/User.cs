﻿using System;
using System.Collections.Generic;
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
        public string Email { get; set; }

        
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }

       
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }

       
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }
        public string Address { get; set; }

    }
}
