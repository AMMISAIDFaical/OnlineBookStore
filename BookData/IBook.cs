using BookCore;
using BookData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData
{
    public interface IBook
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Task<List<Book>> GetBooksBySeller(int seller_id);
        Task<List<Book>> GetBooksByBuyer(int buyer_id);
        Task <Book> GetBookByTitle(string title);
        void AddBook(BookDto book);
        Book RemoveBook(int book);
        Book UpdateBook(int id , BookDto book);
        Task Commit();
        //void GetBookImage(Book book);
        //void AddBookImage(Book book);   
         
    }
}
