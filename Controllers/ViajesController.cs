using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBViajes.Data;
using WEBViajes.Models;

namespace WEBViajes.Controllers
{
    public class ViajesController : Controller
    {
        private readonly ViajesContext _context;

        public ViajesController(ViajesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viajes = _context.Viajes
                           .Include(v => v.Cliente)
                           .Include(v => v.Chofer) 
                           .ToList();
            return View(viajes);
        }

        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Clientes.ToList();
            ViewBag.Choferes = _context.Choferes.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaje viaje)
        {
            ModelState.Remove("Cliente");
            ModelState.Remove("Chofer");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    var key = error.Key;
                    var errors = error.Value.Errors.Select(e => e.ErrorMessage).ToList();
                    Console.WriteLine($"Campo: {key}, Errores: {string.Join(", ", errors)}");
                }
                ViewBag.Clientes = _context.Clientes.ToList();
                ViewBag.Choferes = _context.Choferes.ToList();
                return View(viaje);
            }

            _context.Viajes.Add(viaje);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EnviarLink(int id)
        {
            var viaje = _context.Viajes.Find(id);
            if (viaje != null && !string.IsNullOrEmpty(viaje.LinkPago))
            {
                TempData["Mensaje"] = $"Link enviado: {viaje.LinkPago}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}