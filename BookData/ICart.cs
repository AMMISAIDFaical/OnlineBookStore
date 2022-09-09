using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public interface ICart
    {
        List<Cart> GetAllCart();
        Cart GetCartById(int id);
        Cart GetCartByBuyerId(int buyer_id);
        List<Book> GetCartBooks(int buyerId);
        void AddBookToCart(int bookId, int buyerId);
        void AddCartBuyer(int buyerId);

    }
}
