using BookCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public interface IBook
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void AddBook(Book book);
        Book RemoveBook(int book);
        Book UpdateBook(int id , Book book);
        void Commit();
    }
}
