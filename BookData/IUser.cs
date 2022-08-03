using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public interface IUser
    {
        Buyer GetBuyerById(int id);
        Seller GetSellerById(int id);
        IEnumerable <Buyer> GetBuyers();
        IEnumerable<Seller> GetSellers();
        void AddBuyer (Buyer buyer);
        void AddSeller (Seller seller);
        void RemoveBuyer (Buyer buyer);
        void RemoveSeller (Seller seller);
        Buyer UpdateBuyer(int id, Buyer new_buyer);
        Seller UpdateSeller(int id, Seller new_seller);

    }
}
