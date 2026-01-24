using System.Collections.Generic;
using System.Linq;
using IntroAsp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntroAsp.ViewModels
{
    public class FormViewModel
    {
        public Author AuthorForm { get; set; } = new Author();
        public Book BookForm { get; set; } = new Book();
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
        public IEnumerable<SelectListItem> AuthorOptions { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
