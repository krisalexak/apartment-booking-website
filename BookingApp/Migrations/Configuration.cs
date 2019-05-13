namespace MvcUserRoles.Migrations
{
    using Microsoft.AspNet.Identity;
    using MvcUserRoles.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcUserRoles.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcUserRoles.Models.ApplicationDbContext";
        }

        protected override void Seed(MvcUserRoles.Models.ApplicationDbContext context)
        {

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Properties, reseed, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT(Bookings, reseed, 0)");


            context.Properties.RemoveRange(context.Properties);
            context.Bookings.RemoveRange(context.Bookings);

            context.SaveChanges();
                
            context.Properties.AddOrUpdate(p => p.Id,
                new Property() { Id = 1, Name = "Apartment 1", Description = "This is a description for apartment 1", City = "Paris", Country = "France", PricePerNight = 40, Image = "apartment1.jpg", Guests = 4, Beds = 2, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 2, Name = "Apartment 2", Description = "This is a description for apartment 2", City = "Paris", Country = "France", PricePerNight = 35, Image = "apartment2.jpg", Guests = 3, Beds = 1, Rooms = 2, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 3, Name = "Apartment 3", Description = "This is a description for apartment 3", City = "Paris", Country = "France", PricePerNight = 50, Image = "apartment3.jpg", Guests = 2, Beds = 1, Rooms = 2, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 4, Name = "Apartment 4", Description = "This is a description for apartment 4", City = "Paris", Country = "France", PricePerNight = 54, Image = "apartment4.jpg", Guests = 2, Beds = 1, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 5, Name = "Apartment 5", Description = "This is a description for apartment 5", City = "Paris", Country = "France", PricePerNight = 22, Image = "apartment5.jpg", Guests = 3, Beds = 2, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 6, Name = "Apartment 6", Description = "This is a description for apartment 6", City = "Paris", Country = "France", PricePerNight = 18, Image = "apartment6.jpg", Guests = 4, Beds = 3, Rooms = 4, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 7, Name = "Apartment 7", Description = "This is a description for apartment 7", City = "Paris", Country = "France", PricePerNight = 44, Image = "apartment7.jpg", Guests = 3, Beds = 3, Rooms = 4, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 8, Name = "Apartment 8", Description = "This is a description for apartment 8", City = "Paris", Country = "France", PricePerNight = 43, Image = "apartment8.jpg", Guests = 5, Beds = 3, Rooms = 5, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 9, Name = "Apartment 9", Description = "This is a description for apartment 9", City = "Paris", Country = "France", PricePerNight = 78, Image = "apartment9.jpg", Guests = 2, Beds = 2, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 10, Name = "Apartment 10", Description = "This is a description for apartment 10", City = "Paris", Country = "France", PricePerNight = 66, Image = "apartment10.jpg", Guests = 3, Beds = 3, Rooms = 2, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 11, Name = "Apartment 11", Description = "This is a description for apartment 11", City = "Lyon", Country = "France", PricePerNight = 56, Image = "apartment11.jpg", Guests = 2, Beds = 1, Rooms = 1, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 12, Name = "Apartment 12", Description = "This is a description for apartment 12", City = "Lyon", Country = "France", PricePerNight = 43, Image = "apartment12.jpg", Guests = 3, Beds = 3, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 13, Name = "Apartment 13", Description = "This is a description for apartment 13", City = "Lyon", Country = "France", PricePerNight = 24, Image = "apartment13.jpg", Guests = 1, Beds = 1, Rooms = 2, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 14, Name = "Apartment 14", Description = "This is a description for apartment 14", City = "Lyon", Country = "France", PricePerNight = 29, Image = "apartment14.jpg", Guests = 1, Beds = 1, Rooms = 2, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 15, Name = "Apartment 15", Description = "This is a description for apartment 15", City = "Lyon", Country = "France", PricePerNight = 27, Image = "apartment15.jpg", Guests = 4, Beds = 2, Rooms = 4, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 16, Name = "Apartment 16", Description = "This is a description for apartment 16", City = "Lyon", Country = "France", PricePerNight = 33, Image = "apartment16.jpg", Guests = 3, Beds = 2, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 17, Name = "Apartment 17", Description = "This is a description for apartment 17", City = "Lyon", Country = "France", PricePerNight = 48, Image = "apartment17.jpg", Guests = 3, Beds = 3, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 18, Name = "Apartment 18", Description = "This is a description for apartment 18", City = "Lyon", Country = "France", PricePerNight = 77, Image = "apartment18.jpg", Guests = 4, Beds = 4, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 19, Name = "Apartment 19", Description = "This is a description for apartment 19", City = "Lyon", Country = "France", PricePerNight = 88, Image = "apartment19.jpg", Guests = 4, Beds = 4, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 20, Name = "Apartment 20", Description = "This is a description for apartment 20", City = "Lyon", Country = "France", PricePerNight = 61, Image = "apartment20.jpg", Guests = 3, Beds = 2, Rooms = 3, Category = Category.Apartment, ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad" },
                new Property() { Id = 21, Name = "House 1", Description = "This is a description for house 1", City = "Athens", Country = "Greece", PricePerNight = 61, Image = "house1.jpg", Guests = 3, Beds = 2, Rooms = 4, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 22, Name = "House 2", Description = "This is a description for house 2", City = "Athens", Country = "Greece", PricePerNight = 40, Image = "house2.jpg", Guests = 2, Beds = 3, Rooms = 4, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 23, Name = "House 3", Description = "This is a description for house 3", City = "Athens", Country = "Greece", PricePerNight = 44, Image = "house3.jpg", Guests = 4, Beds = 4, Rooms = 3, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 24, Name = "House 4", Description = "This is a description for house 4", City = "Athens", Country = "Greece", PricePerNight = 33, Image = "house4.jpg", Guests = 3, Beds = 2, Rooms = 2, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 25, Name = "House 5", Description = "This is a description for house 5", City = "Patra", Country = "Greece", PricePerNight = 18, Image = "house5.jpg", Guests = 3, Beds = 1, Rooms = 4, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 26, Name = "House 6", Description = "This is a description for house 6", City = "Patra", Country = "Greece", PricePerNight = 20, Image = "house6.jpg", Guests = 2, Beds = 2, Rooms = 4, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" },
                new Property() { Id = 27, Name = "House 7", Description = "This is a description for house 7", City = "Patra", Country = "Greece", PricePerNight = 55, Image = "house7.jpg", Guests = 1, Beds = 2, Rooms = 4, Category = Category.House, ApplicationUserId = "ee0ba821-a6f4-4115-a4c2-31a3eb172a05" }

            );
            context.SaveChanges();

            context.Bookings.AddOrUpdate(b => b.Id,
                new Booking() { Id = 1, ApplicationUserId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", Price = 160, PropertyId = 1, StartDate = new DateTime(2019, 3, 25), EndDate = new DateTime(2019, 3, 29), Guests = 1 },
                new Booking() { Id = 2, ApplicationUserId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", Price = 170, PropertyId = 2, StartDate = new DateTime(2019, 2, 10), EndDate = new DateTime(2019, 2, 15), Guests = 1 }
            );
            context.SaveChanges();

            context.Messages.AddOrUpdate(m => m.Id,
              new Message() { Id = 1, Body = "Hi, do you provide high-speed WiFi?", DateOfMessage = new DateTime(2008, 5, 1, 8, 30, 52), OwnerOrTraveler = "Traveler", ApplicationUserId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", ReceiverId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad", PropertyId = 2 },
              new Message() { Id = 2, Body = "Yes we have 100 MBPS fiber optic internet..", DateOfMessage = new DateTime(2008, 5, 2, 8, 38, 52), OwnerOrTraveler = "Owner", ApplicationUserId = "09f07c11-fb1e-4828-8a8d-5fc8740e93ad", ReceiverId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", PropertyId = 2 }

              );

            context.SaveChanges();

            context.Reviews.AddOrUpdate(m => m.Id,
                new Review() { Id = 1, ApplicationUserId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", Message = "Wow this is the best apartment i have ever visited. Highly recommended !", PropertyId = 1 },
                new Review() { Id = 2, ApplicationUserId = "e54670a4-1d4a-41a3-9fee-99368ef63aa9", Message = "I will definitely visit this place again.", PropertyId = 1 },
                new Review() { Id = 3, ApplicationUserId = "b0e5a150-fe7d-43e0-a3fc-a84ec03ef2b6", Message = "Very clean apartment. The host is super friendly.", PropertyId = 2 }

                );
            context.SaveChanges();
        }
    }
}
