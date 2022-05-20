using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApartmentPicture
    {
      
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ApartmentId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public bool isRepresentative { get; set; }

        public ApartmentPicture(int apartmentId, string path, string name)
        {
            ApartmentId = apartmentId;
            Path = path;
            Name = name;
        }
        public ApartmentPicture()
        {

        }

    }
}
