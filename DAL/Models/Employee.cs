using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee 
    {
        

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee()
        {

        }
        public Employee(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
