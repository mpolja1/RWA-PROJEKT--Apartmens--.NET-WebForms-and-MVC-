using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApartmentOwner
    {
     

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }

        public ApartmentOwner(int id, Guid guid, DateTime createdAt, string name)
        {
            Id = id;
            Guid = guid;
            CreatedAt = createdAt;
            Name = name;
        }

        public ApartmentOwner()
        {

        }

        public ApartmentOwner(string name)
        {
            Name = name;
        }
    }
}
