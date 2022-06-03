using DAL.Models;
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

        public void AddApartmentTag(int idaparment, int idtag)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(AddApartmentTag), idaparment, idtag);
        }

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

        public User AuthUser(string email, string password)
        {
            var tblUser = SqlHelper.ExecuteDataset(CS, nameof(AuthUser), email, password).Tables[0];
            if (tblUser.Rows.Count == 0) return null;

            DataRow row = tblUser.Rows[0];
            return new User
            {
                Id = (int)row[nameof(User.Id)],
                Guid = (Guid)row[nameof(User.Guid)],
                CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                Email = row[nameof(User.Email)].ToString(),
                PasswordHash = row[nameof(User.PasswordHash)].ToString(),
                UserName = row[nameof(User.UserName)].ToString(),
                Address = row[nameof(User.Address)].ToString()
            };
        }

        public void DeleteApartmentSoft(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteApartmentSoft), id);
        }

        public void deleteApartmentTag(int idaparment, int idtag)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(deleteApartmentTag), idaparment,idtag);
        }

        public void DeleteTag(int id)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(DeleteTag), id);
        }

        public Apartment GetApartmentById(int id)
        {

            var tblapartments = SqlHelper.ExecuteDataset(CS, nameof(GetApartmentById), id).Tables[0];
            foreach (DataRow row in tblapartments.Rows)
            {
                return new Apartment
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

                };
            };

            return null;

        }

        public IList<ApartmentPicture> GetApartmentPictures(int id)
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();
            var tblpicture = SqlHelper.ExecuteDataset(CS,nameof(GetApartmentPictures),id).Tables[0];

            foreach (DataRow row in tblpicture.Rows)
            {
                apartmentPictures.Add(new ApartmentPicture
                {
                    Id = (int)row[nameof(ApartmentPicture.Id)],
                    Guid = (Guid)row[nameof(ApartmentPicture.Guid)],
                    CreatedAt = (DateTime)row[nameof(ApartmentPicture.CreatedAt)],
                    ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)],
                    Path = row[nameof(ApartmentPicture.Path)].ToString(),
                    Name = row[nameof(ApartmentPicture.Name)].ToString(),
                    isRepresentative = (bool)row[nameof(ApartmentPicture.isRepresentative)]
                });
            }

            return apartmentPictures;

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
                apartments.Add(new Apartment
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

        public IList<Tag> GetTagsByApartment(int id)
        {
            List<Tag> taggedApartments = new List<Tag>();
            var tbltagged = SqlHelper.ExecuteDataset(CS, nameof(GetTagsByApartment), id).Tables[0];

            foreach (DataRow row in tbltagged.Rows)
            {
                taggedApartments.Add(new Tag
                {
                    Id = (int)row[nameof(Tag.Id)],
                    Guid = (Guid)row[nameof(Tag.Guid)],
                    Name = row[nameof(Tag.Name)].ToString(),
                    
                });

            }

            return taggedApartments;
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

        public IList<Tag> GetUnusedApartmentTag(int id)
        {
            IList<Tag> utags = new List<Tag>();

            var tbltagged = SqlHelper.ExecuteDataset(CS, nameof(GetUnusedApartmentTag), id).Tables[0];

            foreach (DataRow row in tbltagged.Rows)
            {
                utags.Add(new Tag
                {
                   Id= (int)row[nameof(Tag.Id)],
                   Name = row[nameof(Tag.Name)].ToString()

                }); 
                
            }

            return utags;
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

        public void SaveApartmentImages(ApartmentPicture apartmentpicture)
        {
            SqlHelper.ExecuteNonQuery(CS,nameof(SaveApartmentImages), apartmentpicture.ApartmentId, apartmentpicture.Path, apartmentpicture.Name);
        }

        public void SaveApartmentReservation(int idapartment, ApartmentReservation apartmentReservation)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SaveApartmentReservation), idapartment, apartmentReservation.Details,
           apartmentReservation.UserName, apartmentReservation.UserEmail, apartmentReservation.UserPhone, apartmentReservation.UserAddress);
        }

        public void SaveTag(Tag tag)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SaveTag), tag.TypeId, tag.Name, tag.NameEng);
        }

        public void SaveUser(User user)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(SaveUser), user.Email, user.PasswordHash, user.PhoneNumber, user.UserName, user.Address);
        }

        public List<Apartment> SearchAparments(ApartmenSearchModel searchModel)
        {
            var apartments = GetApartments();

            if (searchModel != null)
            {
                if (searchModel.Room.HasValue)
                {
                    apartments = apartments.Where(x => x.TotalRooms == searchModel.Room).ToList();
                }
                if (searchModel.Adult.HasValue)
                {
                    apartments = (List<Apartment>)apartments.Where(x => x.MaxAdults == searchModel.Adult).ToList();
                }
                if (searchModel.Children.HasValue)
                {
                    apartments = (List<Apartment>)apartments.Where(x => x.MaxChildren == searchModel.Children).ToList();
                }
                if (!string.IsNullOrEmpty(searchModel.Sort))
                {
                    switch (searchModel.Sort)
                    {
                        case "Desc":
                            apartments.Sort((x, y) => -x.Price.CompareTo(y.Price));
                            break;
                        case "Asc":
                            apartments.Sort((x, y) => x.Price.CompareTo(y.Price));
                            break;
                        default:
                            apartments.Sort((x, y) => x.Name.CompareTo(y.Name));
                            break;
                    }
                }
            }


            return apartments;
        }

        public void UpdateApartment(Apartment apartment)
        {
            SqlHelper.ExecuteNonQuery(CS, nameof(UpdateApartment), apartment.Id, apartment.Owner.Name, apartment.Status.Id,
                apartment.City.Id, apartment.Address, apartment.Name, apartment.NameEng, apartment.Price, apartment.MaxAdults,
                apartment.MaxChildren, apartment.TotalRooms, apartment.BeachDistance);
        }
    }
}
