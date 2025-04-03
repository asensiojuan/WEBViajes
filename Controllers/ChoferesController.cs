using Microsoft.AspNetCore.Mvc;
using WEBViajes.Data;
using WEBViajes.Models;

namespace WEBViajes.Controllers
{
    public class ChoferesController : Controller
    {
        private readonly ViajesContext _context;

        public ChoferesController(ViajesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Choferes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                _context.Choferes.Add(chofer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(chofer);
        }
    }
}
