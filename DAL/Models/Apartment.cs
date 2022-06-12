using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Apartment : IComparable<Apartment>
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ApartmentOwner Owner { get; set; }
        public ApartmantStatus Status { get; set; }

        public City City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public decimal Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public int AvgStars { get; set; }
        public List<ApartmentPicture> apartmentPictures { get; set; }

        public Apartment()
        {

        }

        public Apartment(ApartmentOwner owner, ApartmantStatus status, City city, string address, string name, string nameEng, decimal price, int maxAdults, int maxChildren, int totalRooms, int beachDistance)
        {
            Owner = owner;
            Status = status;
            City = city;
            Address = address;
            Name = name;
            NameEng = nameEng;
            Price = price;
            MaxAdults = maxAdults;
            MaxChildren = maxChildren;
            TotalRooms = totalRooms;
            BeachDistance = beachDistance;
        }
        public Apartment(int id,ApartmentOwner owner, ApartmantStatus status, City city, string address, string name, string nameEng, decimal price, int maxAdults, int maxChildren, int totalRooms, int beachDistance)
        {
            Id = id;
            Owner = owner;
            Status = status;
            City = city;
            Address = address;
            Name = name;
            NameEng = nameEng;
            Price = price;
            MaxAdults = maxAdults;
            MaxChildren = maxChildren;
            TotalRooms = totalRooms;
            BeachDistance = beachDistance;
        }

        public Apartment(int id, Guid guid, DateTime createdAt, DateTime? deletedAt, ApartmentOwner owner, ApartmantStatus status, City city, string address, string name, string nameEng, decimal price, int maxAdults, int maxChildren, int totalRooms, int beachDistance)
        {
            Id = id;
            Guid = guid;
            CreatedAt = createdAt;
            DeletedAt = deletedAt;
            Owner = owner;
            Status = status;
            City = city;
            Address = address;
            Name = name;
            NameEng = nameEng;
            Price = price;
            MaxAdults = maxAdults;
            MaxChildren = maxChildren;
            TotalRooms = totalRooms;
            BeachDistance = beachDistance;
        }

        public int CompareTo(Apartment other)
        {
            return -Price.CompareTo(other.Price);
        }
    }
}
