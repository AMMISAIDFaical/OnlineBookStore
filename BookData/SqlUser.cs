using BookCore;
using BookData.DTOs;
using Microsoft.EntityFrameworkCore;
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
        public async void AddBuyer(BuyerDto buyer)
        {
            if (buyer != null)
            {
                Buyer buyerCore = new Buyer();
                buyerCore.Adress = buyer.Adress;
                buyerCore.Ship_Adress = buyer.Adress;
                buyerCore.First_name = buyer.First_name;
                buyerCore.Last_name = buyer.Last_name;
                buyerCore.AspUserId = buyer.AspUserId;
                await _context.Buyers.AddAsync(buyerCore);
                await _context.SaveChangesAsync();
            }
        }

        public async void AddSeller(SellerDto seller)
        {
            if (seller != null)
            {
                Seller sellerCore = new Seller();
                sellerCore.Adress = seller.Adress;
                sellerCore.Discount = seller.Discount;
                sellerCore.First_name = seller.First_name;
                sellerCore.Last_name = seller.Last_name;
                sellerCore.AspUserId = seller.AspUserId;
                await _context.Sellers.AddAsync(sellerCore);
                await _context.SaveChangesAsync();
            }
        }

        public void Commit()
        {
             _context.SaveChangesAsync();
        }

        public  async Task<Buyer> GetBuyerById(int id)
        {
            var b = await _context.Buyers.FirstOrDefaultAsync(b => b.Id == id);
            return b;
        }

        public async Task<List<Buyer>> GetBuyers()
        {
            var all_buyers =  await _context.Buyers.ToListAsync();
            return all_buyers;
        }

        public async Task<Seller> GetSellerById(int id)
        {
            var s = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == id);
            return s;
        }

        public async Task<List<Seller>> GetSellers()
        {
            var all_sellers = await _context.Sellers.ToListAsync();
            return all_sellers;
        }

        public Buyer RemoveBuyer(int buyer_id)
        {
            var removed_buyer = _context.Buyers.FirstOrDefault(b => b.Id == buyer_id);
            _context.Buyers.Remove(removed_buyer);
            _context.SaveChanges();
            return removed_buyer;
        }

        public Seller RemoveSeller(int seller_id)
        {
            var removed_seller = _context.Sellers.FirstOrDefault(s => s.Id == seller_id);
            _context.Sellers.Remove(removed_seller);
            _context.SaveChanges();
            return removed_seller;
        }

        public async Task<Buyer> GetBuyerByAspUserId(string aspNetUser_id)
        {
            var buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.AspUserId == aspNetUser_id);
            return buyer;
        }

    }
}
