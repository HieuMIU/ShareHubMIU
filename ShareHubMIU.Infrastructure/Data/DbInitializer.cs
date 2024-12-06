using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).Wait();
                }

                if (_userManager.Users.All(u => u.Email != "admin@gmail.com"))
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        Name = "Hugh Tran",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        PhoneNumber = "641222222",
                    };

                    var adminResult = _userManager.CreateAsync(adminUser, "Admin123@").Result;
                    if (adminResult.Succeeded)
                    {
                        _userManager.AddToRoleAsync(adminUser, SD.Role_Admin).Wait();
                    }
                }

                // Create the customer user
                if (_userManager.Users.All(u => u.Email != "first.seller@gmail.com"))
                {
                    var customerUser = new ApplicationUser
                    {
                        UserName = "first.seller@gmail.com",
                        Email = "first.seller@gmail.com",
                        Name = "Hieu",
                        NormalizedUserName = "FIRST.SELLER@GMAIL.COM",
                        NormalizedEmail = "FIRST.ELLER@GMAIL.COM",
                        PhoneNumber = "6413333333",
                    };

                    var customerResult = _userManager.CreateAsync(customerUser, "Cusomer123@").Result;
                    if (customerResult.Succeeded)
                    {
                        _userManager.AddToRoleAsync(customerUser, SD.Role_Customer).Wait();
                    }
                }

                // Use the correct query after awaiting the tasks
                var customer = _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == "first.seller@gmail.com").Result;

                // Ensure customer is not null
                if (customer == null)
                {
                    throw new Exception("Customer user creation failed.");
                }

                // Continue with initialization
                InitializeCarSharing();
                InitializeCommonItemsAndRoomSharing();
            }
            catch (Exception ex)
            {
                // Handle exception (optional logging)
                throw;
            }

        }

        public void InitializeCarSharing()
        {
            try
            {
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "first.seller@gmail.com");

                // Check if there are any car-sharing records in the database
                if (!_db.CarSharings.Any())
                {
                    var carSharings = new List<CarSharing>
                    {
                        new CarSharing()
                        {
                            Title = "Toyota Corolla 2020",
                            Description = "Well-maintained, fuel-efficient sedan perfect for city driving.",
                            Type = SD.CategoryTypeCarSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 4B",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            SellerId = user.Id,
                            Seller = user,
                            Make = "Toyota",
                            Model = "Corolla",
                            Year = 2020,
                            Color = "White",
                            Mileage = 25000,
                            FuelType = "Gasoline",
                            Transmission = "Automatic",
                            NumberOfSeats = 5,
                            Condition = "Good",
                            Price = 50,
                            AvailableFrom = DateTime.Now.AddDays(1),
                            AvailableUntil = DateTime.Now.AddDays(30),
                        },
                        new CarSharing
                        {
                            Title = "Honda Civic 2018",
                            Description = "Reliable and compact car with excellent fuel efficiency.",
                            Type = SD.CategoryTypeCarSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "456 Oak St",
                            AddressLine2 = "Suite 101",
                            City = "Los Angeles",
                            State = "CA",
                            ZipCode = "90001",
                            SellerId = user.Id,
                            Seller = user,
                            Make = "Honda",
                            Model = "Civic",
                            Year = 2018,
                            Color = "Black",
                            Mileage = 45000,
                            FuelType = "Gasoline",
                            Transmission = "Manual",
                            NumberOfSeats = 5,
                            Condition = "Excellent",
                            Price = 40,
                            AvailableFrom = DateTime.Now.AddDays(2),
                            AvailableUntil = DateTime.Now.AddDays(20),
                        },
                        new CarSharing
                        {
                            Title = "Ford Mustang 2021",
                            Description = "Powerful sports car with a stunning design and smooth performance.",
                            Type = SD.CategoryTypeCarSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "789 Pine St",
                            AddressLine2 = "Unit 2",
                            City = "Chicago",
                            State = "IL",
                            ZipCode = "60601",
                            SellerId = user.Id,
                            Seller = user,
                            Make = "Ford",
                            Model = "Mustang",
                            Year = 2021,
                            Color = "Red",
                            Mileage = 12000,
                            FuelType = "Gasoline",
                            Transmission = "Automatic",
                            NumberOfSeats = 4,
                            Condition = "Excellent",
                            Price = 100,
                            AvailableFrom = DateTime.Now.AddDays(5),
                            AvailableUntil = DateTime.Now.AddDays(15),
                        },
                        new CarSharing
                        {
                            Title = "Chevrolet Malibu 2019",
                            Description = "Stylish sedan with great comfort and fuel efficiency.",
                            Type = SD.CategoryTypeCarSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusCancelled,
                            AddressLine1 = "1000 Sunset Blvd",
                            AddressLine2 = "Apt 9C",
                            City = "Los Angeles",
                            State = "CA",
                            ZipCode = "90067",
                            SellerId = user.Id,
                            Seller = user,
                            Make = "Chevrolet",
                            Model = "Malibu",
                            Year = 2019,
                            Color = "Blue",
                            Mileage = 35000,
                            FuelType = "Gasoline",
                            Transmission = "Automatic",
                            NumberOfSeats = 5,
                            Condition = "Good",
                            Price = 60,
                            AvailableFrom = DateTime.Now.AddDays(3),
                            AvailableUntil = DateTime.Now.AddDays(25),
                        },
                        new CarSharing
                        {
                            Title = "Nissan Altima 2022",
                            Description = "Latest model with advanced safety features and a smooth ride.",
                            Type = SD.CategoryTypeCarSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "500 Liberty Ave",
                            AddressLine2 = "Apt 3A",
                            City = "Miami",
                            State = "FL",
                            ZipCode = "33101",
                            SellerId = user.Id,
                            Seller = user,
                            Make = "Nissan",
                            Model = "Altima",
                            Year = 2022,
                            Color = "Silver",
                            Mileage = 15000,
                            FuelType = "Gasoline",
                            Transmission = "Automatic",
                            NumberOfSeats = 5,
                            Condition = "New",
                            Price = 75,
                            AvailableFrom = DateTime.Now.AddDays(6),
                            AvailableUntil = DateTime.Now.AddDays(20),
                        }                                       
                    };

                    // Add the car-sharing entries to the database
                    _db.CarSharings.AddRange(carSharings);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (you can log the error if needed)
                throw;
            }
        }


        public void InitializeCommonItemsAndRoomSharing()
        {
            try
            {
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "first.seller@gmail.com");

                // Check if there are any CommonItems in the database
                if (!_db.CommonItems.Any())
                {
                    var commonItems = new List<CommonItem>
                        {
                        new CommonItem
                        {
                            Title = "Sofa",
                            Description = "Comfortable 3-seater sofa with soft cushions.",
                            Type = SD.CategoryTypeFuniture.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 4B",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            SellerId = user.Id,
                            Seller = user,
                            Name = "Sofa",
                            Condition = "New",
                            Price = 300
                        },
                        new CommonItem
                        {
                            Title = "Laptop",
                            Description = "15-inch laptop with 8GB RAM and 512GB SSD.",
                            Type = SD.CategoryTypeElectronics.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "456 Oak St",
                            AddressLine2 = "Suite 101",
                            City = "Los Angeles",
                            State = "CA",
                            ZipCode = "90001",
                            SellerId = user.Id,
                            Seller = user,
                            Name = "Laptop",
                            Condition = "Used",
                            Price = 800
                        },
                        new CommonItem
                        {
                            Title = "Dining Table",
                            Description = "Wooden dining table for 6 people.",
                            Type = SD.CategoryTypeFuniture.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "789 Pine St",
                            AddressLine2 = "Unit 2",
                            City = "Chicago",
                            State = "IL",
                            ZipCode = "60601",
                            SellerId = user.Id,
                            Seller = user,
                            Name = "Dining Table",
                            Condition = "New",
                            Price = 200
                        },
                        new CommonItem
                        {
                            Title = "Smartphone",
                            Description = "Latest model with excellent camera and battery life.",
                            Type = SD.CategoryTypeElectronics.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusCancelled,
                            AddressLine1 = "321 Maple St",
                            AddressLine2 = "Apt 5A",
                            City = "San Francisco",
                            State = "CA",
                            ZipCode = "94110",
                            SellerId = user.Id,
                            Seller = user,
                            Name = "Smartphone",
                            Condition = "Used",
                            Price = 500
                        },
                        new CommonItem
                        {
                            Title = "Coffee Table",
                            Description = "Modern coffee table with glass top and wooden frame.",
                            Type = SD.CategoryTypeFuniture.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusSold,
                            AddressLine1 = "123 Elm St",
                            AddressLine2 = "Suite 202",
                            City = "Austin",
                            State = "TX",
                            ZipCode = "73301",
                            SellerId = user.Id,
                            Seller = user,
                            Name = "Coffee Table",
                            Condition = "New",
                            Price = 150
                        }
                    };

                    // Add the CommonItems to the database
                    _db.CommonItems.AddRange(commonItems);
                }

                // Check if there are any RoomSharing records in the database
                if (!_db.RoomSharings.Any())
                {
                    var roomSharings = new List<RoomSharing>
                    {
                        new RoomSharing
                        {
                            Title = "Single Room in 2BHK",
                            Description = "Spacious single room available for rent in a 2BHK apartment.",
                            Type = SD.CategoryTypeRoomSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 4B",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            SellerId = user.Id,
                            Seller = user,
                            Capacity = 1,
                            Price = 800,
                            RoomType = "Single",
                            IsFurnished = true,
                            AvailableFrom = DateTime.Now.AddDays(1),
                            AvailableUntil = DateTime.Now.AddDays(30)
                        },
                        new RoomSharing
                        {
                            Title = "Shared Room in 3BHK",
                            Description = "Shared room in a 3BHK apartment with two other roommates.",
                            Type = SD.CategoryTypeRoomSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusSold,
                            AddressLine1 = "456 Oak St",
                            AddressLine2 = "Suite 101",
                            City = "Los Angeles",
                            State = "CA",
                            ZipCode = "90001",
                            SellerId = user.Id,
                            Seller = user,
                            Capacity = 2,
                            Price = 600,
                            RoomType = "Shared",
                            IsFurnished = true,
                            AvailableFrom = DateTime.Now.AddDays(2),
                            AvailableUntil = DateTime.Now.AddDays(20)
                        },
                        new RoomSharing
                        {
                            Title = "Studio Room in Downtown",
                            Description = "Cozy studio apartment for rent in the heart of downtown.",
                            Type = SD.CategoryTypeRoomSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusCancelled,
                            AddressLine1 = "789 Pine St",
                            AddressLine2 = "Unit 2",
                            City = "Chicago",
                            State = "IL",
                            ZipCode = "60601",
                            SellerId = user.Id,
                            Seller = user,
                            Capacity = 1,
                            Price = 1200,
                            RoomType = "Single",
                            IsFurnished = false,
                            AvailableFrom = DateTime.Now.AddDays(5),
                            AvailableUntil = DateTime.Now.AddDays(15)
                        },
                        new RoomSharing
                        {
                            Title = "Private Room in Shared House",
                            Description = "Private room available in a shared house with shared kitchen and bathroom.",
                            Type = SD.CategoryTypeRoomSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "321 Maple St",
                            AddressLine2 = "Apt 5A",
                            City = "San Francisco",
                            State = "CA",
                            ZipCode = "94110",
                            SellerId = user.Id,
                            Seller = user,
                            Capacity = 1,
                            Price = 900,
                            RoomType = "Single",
                            IsFurnished = true,
                            AvailableFrom = DateTime.Now.AddDays(3),
                            AvailableUntil = DateTime.Now.AddDays(25)
                        },
                        new RoomSharing
                        {
                            Title = "Room for Rent in Suburb",
                            Description = "Quiet room in a peaceful suburban area for rent.",
                            Type = SD.CategoryTypeRoomSharing.ToString(),
                            DateListed = DateTime.Now,
                            Status = SD.ItemStatusAvailable,
                            AddressLine1 = "123 Elm St",
                            AddressLine2 = "Suite 202",
                            City = "Austin",
                            State = "TX",
                            ZipCode = "73301",
                            SellerId = user.Id,
                            Seller = user,
                            Capacity = 1,
                            Price = 700,
                            RoomType = "Single",
                            IsFurnished = true,
                            AvailableFrom = DateTime.Now.AddDays(7),
                            AvailableUntil = DateTime.Now.AddDays(30)
                        }
                    };

                    // Add the RoomSharings to the database
                    _db.RoomSharings.AddRange(roomSharings);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (you can log the error if needed)
                throw;
            }
        }
    }
}
