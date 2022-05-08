using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Irepo
    {
        Employee AuthEmployee(string username, string password);
        List<City> GetCities();
        List<ApartmantStatus> GetApartmentStatus();

        List<Tag> GetTagCount();

        void SaveTag(Tag tag);

        void DeleteTag(int id);

        List<Apartment> GetApartments();
        List<TagType> GetTagTypes();

        void DeleteApartmentSoft(int id);
        void SaveApartment(Apartment apartment);
        IList<User> GetUsers();
       

        //IList<Apartment> GetApartmentsByCity(int id);

    }
}
