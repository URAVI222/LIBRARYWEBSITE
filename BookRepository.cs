using LibraryApplication.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace LibraryApplication.Repositories
{
    public class BookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return [.._context.Books]; 
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id); // Fetch book by ID
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges(); // Save changes to the database
        }

        public bool UpdateBook(Book updatedBook)
        {
            _context.Books.Update(updatedBook);
            return _context.SaveChanges() > 0; // Returns true if the update was successful
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return false; // Book not found
            }

            _context.Books.Remove(book);
            return _context.SaveChanges() > 0; // Returns true if the deletion was successful
        }
    }
}
