using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Tag
    {
       
        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public DateTime? DateTime { get; set; }

        public int? TagCount{ get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public Tag()
        {

        }
        public Tag(int typeId, string name, string nameEng)
        {
            TypeId = typeId;
            Name = name;
            NameEng = nameEng;
        }

        public Tag(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
       => $"{Name}";
    }
}
