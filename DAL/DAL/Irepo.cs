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

        void UpdateApartment(Apartment apartment);
        Apartment GetApartmentById(int id);

        void SaveApartmentReservation(int idapartment, ApartmentReservation apartmentReservation);

        IList<TaggedApartment> GetTagsByApartment(int id);

        void SaveApartmentImages(ApartmentPicture apartmentpicture);
        IList<ApartmentPicture> GetApartmentPictures(int id);

        //IList<Apartment> GetApartmentsByCity(int id);

    }
}
