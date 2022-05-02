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
        IList<City> GetCities();

        IList<ApartmantStatus> GetApartmentStatus();
    }
}
