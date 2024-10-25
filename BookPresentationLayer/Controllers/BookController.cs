using BookDALibrary;
using BookPresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookInfo = BookPresentationLayer.Models.BookInfo;

namespace BookPresentationLayer.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _service;
        public BookController(IBookRepository service)
        {
            _service = service;
        }
        public IActionResult Display()
        {
            List<Book> books = new List<Book>();
            List<BookInfo> bookInfos = new List<BookInfo>();
            books = _service.GetAll();
            foreach (Book book in books)
            {
                BookInfo bookInfo = new BookInfo();
                bookInfo.Id = book.Id;
                bookInfo.name = book.name;
                bookInfo.description = book.description;
                bookInfo.availableStatus = book.availableStatus;

                bookInfos.Add(bookInfo);
            }
            return View(bookInfos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookInfo bookinfo)
        {
            try
            {
                if (bookinfo != null)
                {
                    Book book = new Book();
                    book.Id = bookinfo.Id;
                    book.name = bookinfo.name;
                    book.description = bookinfo.description;
                    book.availableStatus = bookinfo.availableStatus;
                    _service.Add(book);
                    
                }
                return RedirectToAction("Display");
            }
            catch (Exception e)
            {
                throw e;
            }         
        }
        public IActionResult Delete(int id)
        {
            try
            {
                if (id != null)
                {
                    var b = _service.GetBookById(id);
                    BookInfo b1 = new BookInfo();
                    b1.Id = b.Id;
                    b1.name = b.name;
                    b1.description = b.description;
                    b1.availableStatus = b.availableStatus;
                    return View(b1);
                }
                return RedirectToAction("Display");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public IActionResult Delete(BookInfo bookInfo)
        {
            try
            {
                if (bookInfo != null)
                {
                    Book book = new Book();
                    book.Id = bookInfo.Id;
                    book.name = bookInfo.name;
                    book.description = bookInfo.description;
                    book.availableStatus = bookInfo.availableStatus;
                    _service.DeleteBook(book);
                }
                return RedirectToAction("Display");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {
                if (id!=null)
                {
                    var b = _service.GetBookById(id);
                    BookInfo b1 = new BookInfo();
                    b1.Id = b.Id;
                    b1.name = b.name;
                    b1.description = b.description;
                    b1.availableStatus = b.availableStatus;
                    return View(b1);
                }
                return RedirectToAction("Display");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public IActionResult Edit(BookInfo bookInfo)
        {
            try
            {
                if (bookInfo != null)
                {
                    Book book = new Book();
                    book.Id = bookInfo.Id;
                    book.name = bookInfo.name;
                    book.description = bookInfo.description;
                    book.availableStatus = bookInfo.availableStatus;
                    _service.UpdateBook(book);
                }
                return RedirectToAction("Display");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

