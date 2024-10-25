using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace BookDALibrary
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;
        public BookRepository()
        {
            _context = new BookContext();
        }

        public void Add(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteBook(Book book)
        {
            try
            {
                Book b = _context.Books.Find(book.Id);
                if (b != null)
                {
                    _context.Books.Remove(b);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            try
            {
                return _context.Books.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                var b = _context.Books.Find(book.Id);
                if (b != null)
                {
                   
                    b.Id = book.Id;
                    b.name = book.name;
                    b.description = book.description;
                    b.availableStatus = book.availableStatus;
                     _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
