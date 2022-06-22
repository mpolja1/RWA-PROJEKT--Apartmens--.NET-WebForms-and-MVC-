using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani_publicccc.Models.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == providedPassword)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}