using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public class SqlBook: IBook
    {
        private readonly BookDbContext context;

        public SqlBook(BookDbContext context)
        {
            this.context = context;
        }
        public void AddBook(Book book)
        {
            context.Book.Add(book);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public Book GetBook(int id)
        {
            var book = context.Book.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Book.OrderBy(b => b.Id).ToList();
        }

        public Book RemoveBook(int id)
        {
            var book = GetBook(id);
            context.Book.Remove(book);
            return book;
        }

        public Book UpdateBook(int book_id, Book new_book)
        {
            var old_book = GetBook(book_id);

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
                if (old_book.Buyer_Id != new_book.Buyer_Id)
                {
                    old_book.Buyer_Id = new_book.Buyer_Id;
                }
                if (old_book.Seller_Id != new_book.Seller_Id)
                {
                    old_book.Seller_Id = new_book.Seller_Id;
                }
            }
            Commit();
            return old_book;
        }
    }
}
