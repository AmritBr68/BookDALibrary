using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDALibrary
{
    public interface IBookRepository
    {
        public void Add(Book book);
        public bool UpdateBook(Book book);
        public bool DeleteBook(Book book);
        public List<Book> GetAll();
        public Book GetBookById(int id);
    }
}
