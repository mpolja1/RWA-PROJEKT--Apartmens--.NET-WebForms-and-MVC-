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

        IList<Tag> GetTagsByApartment(int id);

        IList<Tag> GetUnusedApartmentTag(int id);

        void deleteApartmentTag(int idaparment, int idtag);

        void AddApartmentTag(int idaparment, int idtag);

        void SaveApartmentImages(ApartmentPicture apartmentpicture);
        IList<ApartmentPicture> GetApartmentPictures(int id);

        User AuthUser(string email, string password);
        void SaveUser(User user);

        List<Apartment> SearchAparments(ApartmenSearchModel searchModel);

        //IList<Apartment> GetApartmentsByCity(int id);

        int GetAvgStarsReview(int id);

    }
}
