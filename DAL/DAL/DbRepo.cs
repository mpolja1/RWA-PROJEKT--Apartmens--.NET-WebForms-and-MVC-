﻿using DAL.Models;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public void DeleteApartmentSoft(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartmentSoft), id);
        }

        public void DeleteTag(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteTag), id);
        }

        public List<Apartment> GetApartments()
        {
            List<Apartment> apartments = new List<Apartment>();

            var apartman = SqlHelper.ExecuteDataset(CS, nameof(GetApartments)).Tables[0];

            //using (SqlConnection conn = new SqlConnection(CS))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("GetApartments", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {

            //       apartments.Add(new Apartment
            //       {


            //           Id = (int)reader[0],
            //        Guid = (Guid)reader[1],
            //        CreatedAt = (DateTime)reader[2],
            //         DeletedAt = (DateTime)reader[3],
            //        Owner = new ApartmentOwner((int)reader[4], (Guid)reader[5], (DateTime)reader[6], reader[7].ToString()),
            //           //Status = new ApartmantStatus((int)reader[8], (Guid)reader[9], reader[10].ToString(), reader[11].ToString()),
            //           //City = new City((int)reader[12], (Guid)reader[13], reader[14].ToString()),
            //           //Address = reader[15].ToString(),
            //           //Name = reader[16].ToString(),
            //           //NameEng = reader[17].ToString(),
            //           ////Price = decimal.Parse(reader[18].ToString()),
            //           //MaxAdults = (int)reader[19],
            //           //MaxChildren = (int)reader[20],
            //           //TotalRooms = (int)reader[21],
            //           //BeachDistance = (int)reader[22]

            //       });

            //    }
            //}

                foreach (DataRow row in apartman.Rows)
                {   
                    apartments.Add( new Apartment
                    {

                        Id = (int)row[nameof(Apartment.Id)],
                        Guid = (Guid)row[nameof(Apartment.Guid)],
                        CreatedAt = (DateTime)row[nameof(Apartment.CreatedAt)],
                        //DeletedAt = (DateTime)row[nameof(Apartment.DeletedAt)],
                        Owner = new ApartmentOwner((int)row["OwnerId"], (Guid)row["OwnerGuid"],
                        (DateTime)row["OwnerCreatedAt"], row["OwnerName"].ToString()),

                        Status = new ApartmantStatus((int)row["StatusID"], (Guid)row["StatusGuid"],
                        row["StatusName"].ToString(), row["StatusNameEng"].ToString()),

                        City = new City((int)row["CityId"], (Guid)row["CityGuid"], row["CityName"].ToString()),

                        Address = row[nameof(Apartment.Address)].ToString(),
                        Name = row[nameof(Apartment.Name)].ToString(),
                        NameEng = row[nameof(Apartment.NameEng)].ToString(),
                        Price = (decimal)row[nameof(Apartment.Price)],
                        MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                        MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                        TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                        BeachDistance = (int)row[nameof(Apartment.BeachDistance)]

                    });
            }
            return apartments;
        }

    public IList<Apartment> GetApartmentsByCity(int id)
    {
        IList<Apartment> apartments = new List<Apartment>();
        var tblapartments = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentsByCity), id).Tables[0];

        foreach (DataRow row in tblapartments.Rows)
        {
            apartments.Add(new Apartment
            {
                Id = (int)row[nameof(Apartment.Id)],
                Guid = (Guid)row[nameof(Apartment.Guid)],
                CreatedAt = (DateTime)row[nameof(Apartment.CreatedAt)],
                //DeletedAt = (DateTime)row[nameof(Apartment.DeletedAt)],
                Owner = new ApartmentOwner((int)row[nameof(ApartmentOwner.Id)], (Guid)row[nameof(ApartmentOwner.Guid)],
               (DateTime)row[nameof(ApartmentOwner.CreatedAt)], row[nameof(ApartmentOwner.Name)].ToString()),


                //StatusId = (int)row[nameof(Apartment.StatusId)],
                //CityId = (int)row[nameof(Apartment.CityId)],
                Address = row[nameof(Apartment.Address)].ToString(),
                Name = row[nameof(Apartment.Name)].ToString(),
                NameEng = row[nameof(Apartment.NameEng)].ToString(),
                Price = (decimal)row[nameof(Apartment.Price)],
                MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                BeachDistance = (int)row[nameof(Apartment.BeachDistance)]
            });
        }


        return apartments;
    }

    public List<ApartmantStatus> GetApartmentStatus()
    {
        List<ApartmantStatus> status = new List<ApartmantStatus>();
        var tblStatus = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentStatus)).Tables[0];

        foreach (DataRow row in tblStatus.Rows)
        {
            status.Add(new ApartmantStatus
            {
                Id = (int)row[nameof(ApartmantStatus.Id)],
                Guid = (Guid)row[nameof(ApartmantStatus.Guid)],
                Name = row[nameof(ApartmantStatus.Name)].ToString(),
                NameEng = row[nameof(ApartmantStatus.NameEng)].ToString()

            }
          );
        }
        return status;
    }

    public List<City> GetCities()
    {
        List<City> cities = new List<City>();
        var tblCities = SqlHelper.ExecuteDataset(CS, nameof(GetCities)).Tables[0];

        foreach (DataRow row in tblCities.Rows)
        {
            cities.Add(new City
            {
                Id = (int)row[nameof(City.Id)],
                Guid = (Guid)row[nameof(City.Guid)],
                Name = row[nameof(City.Name)].ToString(),
            }
          );
        }
        return cities;
    }

    public List<Tag> GetTagCount()
    {
        List<Tag> tagcounts = new List<Tag>();
        var tblTagcounts = SqlHelper.ExecuteDataset(CS, nameof(GetTagCount)).Tables[0];

        foreach (DataRow row in tblTagcounts.Rows)
        {
            tagcounts.Add(new Tag
            {
                Id = (int)row[nameof(Tag.Id)],
                Name = row[nameof(Tag.Name)].ToString(),
                TagCount = (int)row[nameof(Tag.TagCount)]
            });
        }
        return tagcounts;

    }

    public List<TagType> GetTagTypes()
    {
        List<TagType> tagTypes = new List<TagType>();
        var tbltagTypes = SqlHelper.ExecuteDataset(CS, nameof(GetTagTypes)).Tables[0];

        foreach (DataRow row in tbltagTypes.Rows)
        {
            tagTypes.Add(new TagType
            {
                Id = (int)row[nameof(TagType.Id)],
                Guid = (Guid)row[nameof(TagType.Guid)],
                Name = row[nameof(TagType.Name)].ToString(),
                NameEng = row[nameof(TagType.NameEng)].ToString()

            });

        }
        return tagTypes;
    }

    public IList<User> GetUsers()
    {
        IList<User> users = new List<User>();

        var tblusers = SqlHelper.ExecuteDataset(CS, nameof(GetUsers)).Tables[0];
        foreach (DataRow row in tblusers.Rows)
        {
            users.Add(new User
            {
                Id = (int)row[nameof(User.Id)],
                Guid = (Guid)row[nameof(User.Guid)],
                CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                //DeletedAt = (DateTime?)row[nameof(User.DeletedAt)],
                Email = row[nameof(User.Email)].ToString(),
                EmailConfirmed = (bool)row[nameof(User.EmailConfirmed)],
                PasswordHash = row[nameof(User.PasswordHash)].ToString(),
                SecurityStamp = row[nameof(User.SecurityStamp)].ToString(),
                PhoneNumber = row[nameof(User.PhoneNumber)].ToString(),
                //PhoneNumberConfirmed = (bool)row[nameof(User.PhoneNumberConfirmed)],
                //LockoutEndDateUtc = (DateTime?)row[nameof(User.LockoutEndDateUtc)],
                //LockoutEnabled = (bool)row[nameof(User.LockoutEnabled)],
                //AccessFailedCount = (int)row[nameof(User.AccessFailedCount)],
                UserName = row[nameof(User.UserName)].ToString(),
                Address = row[nameof(User.Address)].ToString()

            });

        }
        return users;
    }

    public void SaveApartment(Apartment apartment)
    {
        SqlHelper.ExecuteNonQuery(CS, nameof(SaveApartment), apartment.Owner.Name, apartment.Status.Id, apartment.City.Id,
            apartment.Address, apartment.Name, apartment.NameEng, apartment.Price, apartment.MaxAdults, apartment.MaxChildren,
             apartment.TotalRooms, apartment.BeachDistance);
    }

    public void SaveTag(Tag tag)
    {
        SqlHelper.ExecuteNonQuery(CS, nameof(SaveTag), tag.TypeId, tag.Name, tag.NameEng);
    }
}
}
