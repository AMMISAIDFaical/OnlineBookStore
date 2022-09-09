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
    public class SqlBook: IBook
    {
        private readonly BookDbContext _context;
        private readonly IUser iuser;

        public SqlBook(BookDbContext context, IUser iuser)
        {
            _context = context;
            this.iuser = iuser;
        }
        public void AddBook(BookDto book)
        {
            Book bookCore = new Book();
            bookCore.Title = book.Title;
            bookCore.Publisher = book.Publisher;
            bookCore.ISBN = book.ISBN;
            //default value buyer
            bookCore.BuyerId = 5;
            bookCore.SellerId = book.SellerId;
            //default value cart
            bookCore.CartId = 4;
            _context.Book.Add(bookCore);
            _context.SaveChanges();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Book GetBook(int id)
        {
            var book =  _context.Book.FirstOrDefault(b => b.Id == id);
            return book;
        }
        
        public async Task <List<Book>> GetBooksBySeller (int seller_id)
        {
            var books = await _context.Book.Where(b => b.SellerId == seller_id).ToListAsync();
            return books;
        }
        public async Task<List<Book>> GetBooksByBuyer(int buyer_id)
        {
            var books = await _context.Book.Where(b => b.BuyerId == buyer_id).ToListAsync();
            return books;
        }
        public async Task<Book> GetBookByTitle(string title)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.Title == title);
            return book;
        }

        public List<Book> GetBooks()
        {   
            var books = _context.Book.ToList();
            var number = books.Count();
            return books;
        }

        public Task<List<Book>> GetBooksByBuyerId(int buyerId)
        {
            var books = _context.Book.Where(b => b.BuyerId == buyerId).ToListAsync();
            return books;
        }

        public Task<List<Book>> GetBooksBySellerId(int sellerId)
        {
            var books = _context.Book.Where(b => b.SellerId == sellerId).ToListAsync();
            return books;
        }

        public Book RemoveBook(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.Id == id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return book;
        }

        //not sure if its implemented the right way we will add up mapping later on ...
        public Book UpdateBook(int book_id, BookDto new_book)
        {
            var old_book = _context.Book.FirstOrDefault(b => b.Id == book_id);
            
            if (old_book != null && new_book != null)
            {
                if (old_book.Id != new_book.Id && new_book.Id != 0)
                {
                    old_book.Id = new_book.Id;
                }
                if (old_book.Title != new_book.Title)
                {
                    old_book.Title = new_book.Title;
                }
                if (old_book.Publisher != new_book.Publisher)
                {
                    old_book.Publisher = new_book.Publisher;
                }
                if (old_book.BuyerId != new_book.BuyerId)
                {
                    old_book.BuyerId = (int)new_book.BuyerId;
                }
                 if (old_book.SellerId != new_book.SellerId)
                 {
                     old_book.SellerId = new_book.SellerId;
                 }
             }
             Commit();
             return old_book;

        }

    }
}
