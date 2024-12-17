using Microsoft.AspNetCore.Mvc;
using LibraryApplication.Models;
using System.Collections.Generic;
using LibraryApplication.Repositories;

namespace LibraryApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book); // Add the book to the database
                return RedirectToAction("Index"); // Redirect to the index or a success page
            }

            return View(book); // Return to the view with the current book data if the model state is invalid
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.GetBookById(id); // Fetch the book by ID from the database
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                var result = _bookRepository.UpdateBook(updatedBook); // Update the book in the database
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View("Edit", updatedBook);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetBookById(id); // Fetch the book by ID from the database
            if (book == null)
            {
                return NotFound();
            }
            var result = _bookRepository.DeleteBook(id); // Remove the book from the database
            if (result)
            {
                return RedirectToAction("Index"); // Redirect back to the Index page
            }
            return NotFound();// Optional: You can show a confirmation page before deleting
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
            
        //}
    }
}
