using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Serializable]
    public class City
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public City()
        {

        }

        public City(int id, Guid guid, string name)
        {
            Id = id;
            Guid = guid;
            Name = name;
        }

        public City(string name)
        {
            Name = name;
        }

        public override string ToString()
        => $"{Name}";
    }
}
