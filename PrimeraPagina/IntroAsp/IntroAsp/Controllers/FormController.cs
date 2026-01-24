using IntroAsp.Models;
using IntroAsp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IntroAsp.Controllers
{
    public class FormController : Controller
    {
        // Inyección de dependencias del contexto de la base de datos
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(BuildFormViewModel());
        }


        // BookController

        // 1. Listar

        public IActionResult IndexBooks()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .ToList();
            return View(books);
        }

        // 2. Crear

        public IActionResult CrateBooks()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBooks([Bind(Prefix = "BookForm")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", BuildFormViewModel(bookForm: book));
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // AuthorController

        // 1. Listar
        public IActionResult IndexAuthor()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        // 2. Crear

        public IActionResult CreateAuthor()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAuthor([Bind(Prefix = "AuthorForm")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", BuildFormViewModel(authorForm: author));
            }

            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private FormViewModel BuildFormViewModel(Book? bookForm = null, Author? authorForm = null)
        {
            var authors = _context.Authors.OrderBy(a => a.AuthorName).ToList();
            var books = _context.Books
                .Include(b => b.Author)
                .ToList();

            return new FormViewModel
            {
                BookForm = bookForm ?? new Book(),
                AuthorForm = authorForm ?? new Author(),
                Books = books,
                AuthorOptions = authors
                    .Select(a => new SelectListItem
                    {
                        Value = a.AuthorId.ToString(),
                        Text = a.AuthorName
                    })
                    .ToList()
            };
        }
    }
}


