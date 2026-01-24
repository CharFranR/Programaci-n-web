// Comentado ya que se maneja desde Form


//using Microsoft.AspNetCore.Mvc;
//using IntroAsp.Models;

//namespace IntroAsp.Controllers
//{
//    public class BookController : Controller
//    {
//        // Inyección de dependencias del contexto de la base de datos
//        private readonly ApplicationDbContext _context;

//        public BookController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // 1. Listar

//        public IActionResult Index()
//        {
//            var books = _context.Books.ToList();
//            return View(books);
//        }

//        // 2. Crear

//        public IActionResult Crate()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create()
//        {
//            return View();
//        }


//        // 3. Editar
//        // 4. Eliminar
//    }
//}
