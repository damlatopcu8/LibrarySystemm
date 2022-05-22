using LibrarySystemm.Models;
using LibrarySystemm.Services;
using Microsoft.AspNetCore.Mvc;



namespace LibrarySystemm.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetList();
            return View(books);
        }

        /* Yeni Bir Todo Ekleme */
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookService.Create(book);
            return RedirectToAction("Index");
        }

        /* Belirli Bir Todo Guncelleme */
        public IActionResult Update(string Id)
        {
            var book = _bookService.GetById(Id);
            return View(book);
        }


        [HttpPost]
        public IActionResult Update(string Id, Book book)
        {
            var item = _bookService.GetById(Id);
            item.ISBN = book.ISBN;
            item.NAME = book.NAME;
            item.PAGENUMBER = book.PAGENUMBER;
            item.LANGUAGE = book.LANGUAGE;
            item.CATEGORY = book.CATEGORY;
            item.Completed = book.Completed;
            _bookService.Update(Id, item);
            return RedirectToAction("Index");
        }

        /* Belirli Bir Todo Silmek */
        public IActionResult Delete(string Id)
        {
            var book = _bookService.GetById(Id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(string Id, IFormCollection collection)
        {
            _bookService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}


