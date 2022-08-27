using BookCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class BookDbContext:IdentityDbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
    