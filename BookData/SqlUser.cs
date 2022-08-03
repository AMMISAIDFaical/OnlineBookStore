using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class SqlUser : IUser
    {
        private readonly BookDbContext _context;

        public SqlUser(BookDbContext context)
        {
            _context = context;
        }
        public void AddBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public void AddSeller(Seller seller)
        {
            throw new NotImplementedException();
        }

        public Buyer GetBuyerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Buyer> GetBuyers()
        {
            throw new NotImplementedException();
        }

        public Seller GetSellerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seller> GetSellers()
        {
            throw new NotImplementedException();
        }

        public void RemoveBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeller(Seller seller)
        {
            throw new NotImplementedException();
        }

        public Buyer UpdateBuyer(int id, Buyer new_buyer)
        {
            throw new NotImplementedException();
        }

        public Seller UpdateSeller(int id, Seller new_seller)
        {
            throw new NotImplementedException();
        }
    }
}
