using BookCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class BookDbContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "BOOK 1",
                    Publisher = "PUB 1",
                    ISBN = "111111111",
                    Buyer_Id = 1,
                    Seller_Id = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "BOOK 2",
                    Publisher = "PUB 2",
                    ISBN = "111111111",
                    Buyer_Id = 2,
                    Seller_Id = 2
                });
            modelBuilder.Entity<Buyer>().HasData(
                new Buyer()
                {
                    First_name = "jimmy",
                    Last_name = "butler",
                    Email_id = 1,
                    Password = "butlercode",
                    Adress = "chicago st 12",
                    Country = "USA",
                    City = "chicago",
                    State = "chicago",
                    Phone = "05632458",
                    ZipCode = 0111,
                    Id =1,
                    Ship_Adress ="cleveland"
                },

                new Buyer()
                {
                    First_name = "zach",
                    Last_name = "lavin",
                    Email_id = 2,
                    Password = "lavinecode",
                    Adress = "minisota st 22",
                    Country = "USA",
                    City = "minisota",
                    State = "minisota",
                    Phone = "05688499",
                    ZipCode = 0220,
                    Id = 2,
                    Ship_Adress = "minisota"
                });
            modelBuilder.Entity<Seller>().HasData(

                new Seller()
                {
                    First_name = "ball",
                    Last_name = "lanzo",
                    Email_id = 1,
                    Password = "ballcode",
                    Adress = "orelance st 22",
                    Country = "USA",
                    City = "orelance",
                    State = "orelance",
                    Phone = "05900779",
                    ZipCode = 0112,
                    Id = 1,
                },
                new Seller()
                {
                    First_name = "paul",
                    Last_name = "chris",
                    Email_id = 2,
                    Password = "chriscode",
                    Adress = "phonex st 22",
                    Country = "USA",
                    City = "phonex",
                    State = "phonex",
                    Phone = "05991179",
                    ZipCode = 0002,
                    Id = 2,
                });
        }
    }
}
