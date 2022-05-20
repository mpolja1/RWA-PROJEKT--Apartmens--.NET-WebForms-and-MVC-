using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApartmantStatus
    {
        
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public ApartmantStatus(int id, Guid guid, string name, string nameEng)
        {
            Id = id;
            Guid = guid;
            Name = name;
            NameEng = nameEng;
        }
        public ApartmantStatus()
        {

        }

        public ApartmantStatus(string name)
        {
            Name = name;
        }

        public override string ToString()
        => $"{Name}";
    }
}
