    using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class SqlCart:ICart
    {
        private readonly BookDbContext _context;
        private readonly IBook _book;

        public SqlCart(BookDbContext context, IBook book)
        {
            _context = context;
            _book = book;
        }

        public void AddCartBuyer (int buyerId)
        {
            var buyer = _context.Buyers.FirstOrDefault(x => x.Id == buyerId);
            if (buyer != null)
            {
                Cart cart = new Cart
                {
                    BuyerId = buyerId,
                };
                _context.Cart.Add(cart);
                _context.SaveChanges();
            }
        }

        public void AddBookToCart ( int buyerId,int bookId)
        {
            var cart = GetCartByBuyerId(buyerId);
            var book = _context.Book.FirstOrDefault(b => b.Id== bookId);
            book.CartId = cart.Id;
            book.BuyerId = buyerId;
            _context.SaveChanges();
        }

        public List<Book> GetCartBooks(int buyerId)
        {
            var cart = _context.Cart.FirstOrDefault(b => b.BuyerId== buyerId);
            var books = _context.Book.Where(b => b.CartId == cart.Id).ToList();
            return books;
        }

        public Cart GetCartById(int id)
        {
            return _context.Cart.FirstOrDefault(c => c.Id == id); 
        }
        
        public Cart GetCartByBuyerId(int buyer_id)
        {
            var cart = _context.Cart.FirstOrDefault(c => c.BuyerId == buyer_id);
            return cart;
        }

        public List<Cart> GetAllCart()
        {
            return _context.Cart.ToList();
        }

       
    }
}
