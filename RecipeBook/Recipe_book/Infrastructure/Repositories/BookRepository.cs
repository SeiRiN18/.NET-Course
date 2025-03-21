using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void Delete(string title)
        {
            var book = GetByTitle(title);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public List<Book> FilterBooks(Func<Book, bool> filter)
        {
            return _books.Where(filter).ToList();
        }

        public List<Book> FilterBooksByAuthor(string author)
        {
            return FilterBooks(x => x.Author == author);
        }

        public List<Book> FilterBooksByTitle(string title)
        {
            return FilterBooks(x=>x.Title == title);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book GetByTitle(string title)
        {
            return _books.First(x => x.Title == title);
        }
    }
}
