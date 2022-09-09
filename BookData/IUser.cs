using BookCore;
using BookData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public interface IUser
    {

        Task<List<Seller>> GetSellers();
        Task<List<Buyer>> GetBuyers();
        Task<Buyer> GetBuyerById(int id);
        Task<Seller> GetSellerById(int id);
        void AddBuyer (BuyerDto buyer);
        void AddSeller (SellerDto seller);
        Buyer RemoveBuyer (int buyer_id);
        Seller RemoveSeller (int seller_id);
        void Commit();
        Task<Buyer> GetBuyerByAspUserId(string aspNetUser_id);
    }
}
