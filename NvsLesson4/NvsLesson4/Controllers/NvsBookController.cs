using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NvsLesson04.Models;

namespace NvsLesson04.Controllers
{
    public class NvsBookController : Controller
    {
        protected Book book = new Book();
        public IActionResult NvsIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            var books = book.GetBookList();
            return View(books);
        }
    }
}