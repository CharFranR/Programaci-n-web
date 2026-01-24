// Comentado ya que se maneja desde Form

//using Microsoft.AspNetCore.Mvc;
//using IntroAsp.Models;

//namespace IntroAsp.Controllers
//{
//    public class AuthorController : Controller
//    {
//        // Se realiza la inyección de dependencias del contexto de la base de datos
//        private readonly ApplicationDbContext _context;
        
//        public AuthorController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Se agregan las acciones para manejar las operaciones CRUD de los autores

//        // 1. Listar
//        public IActionResult Index()
//        {
//            var authors = _context.Authors.ToList();
//            return View(authors);
//        }

//        // 2. Crear

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Author author)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Authors.Add(author);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(author);
//        }

//        // 3. Editar 

//        // 4. Eliminar


//    }
//}
