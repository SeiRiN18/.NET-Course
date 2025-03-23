using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        List<Book> GetBooks();
        Book GetByTitle(string title);
        void Delete(string title);


        List<Book> FilterBooks(Func<Book, bool> filter);


    }
}
