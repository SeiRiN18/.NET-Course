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
        private const string FilePath = "Books.txt";

        private List<Book> _books;


       
        public BookRepository()
        {
            _books = LoadBooks();
        }
        private void SaveBooks()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath,false))
                {
                    foreach (var book in _books)
                    {
                        sw.WriteLine($"{book.Title}|{book.Author}|{book.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private List<Book> LoadBooks()
        {
            var books = new List<Book>();
            try
            {
                if (!File.Exists(FilePath))
                {
                    try
                    {
                        File.WriteAllText(FilePath,"");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    return books;

                }
                else
                {
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            books.Add(new Book(parts[0], parts[1], parts[2]));

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return books;
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
            SaveBooks();
        }

        public void Delete(string title)
        {
            var book = GetByTitle(title);
            if (book != null)
            {
                _books.Remove(book);
                SaveBooks() ;
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
