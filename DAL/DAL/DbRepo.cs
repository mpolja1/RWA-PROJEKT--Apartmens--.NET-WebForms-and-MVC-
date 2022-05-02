using DAL.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class DbRepo : Irepo
    {
        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public Employee AuthEmployee(string username, string password)
        {
            var tblAuth = SqlHelper.ExecuteDataset(CS, nameof(AuthEmployee), username, password).Tables[0];
            if (tblAuth.Rows.Count == 0) return null;

            DataRow row = tblAuth.Rows[0];
            return new Employee
            {
                Id = (int)row[nameof(Employee.Id)],
                Username = row[nameof(Employee.Username)].ToString(),
                Password = row[nameof(Employee.Password)].ToString()
            };
        }

        public IList<ApartmantStatus> GetApartmentStatus()
        {
            IList<ApartmantStatus> status = new List<ApartmantStatus>();
            var tblStatus = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentStatus)).Tables[0];

            foreach (DataRow row in tblStatus.Rows)
            {
                status.Add(new ApartmantStatus
                {
                    Id = (int)row[nameof(ApartmantStatus.Id)],
                    Guid = row[nameof(ApartmantStatus.Guid)].ToString(),
                    Name = row[nameof(ApartmantStatus.Name)].ToString(),
                    NameEng = row[nameof(ApartmantStatus.NameEng)].ToString()
                 
                }
              );
            }
            return status;
        }

        public IList<City> GetCities()
        {
            IList<City> cities = new List<City>();
            var tblCities = SqlHelper.ExecuteDataset(CS, nameof(GetCities)).Tables[0];
            
            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(new City
                {
                    Id = (int)row[nameof(City.Id)],
                    Guid = row[nameof(City.Guid)].ToString(),
                    Name = row[nameof(City.Name)].ToString(),
                }
              );  
            }
            return cities;
        }
    }
}
