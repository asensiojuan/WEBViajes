using Microsoft.AspNetCore.Mvc;
using WEBViajes.Data;
using WEBViajes.Models;

namespace ViajesMVPv1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ViajesContext _context;

        public ClientesController(ViajesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clientes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
    }
}