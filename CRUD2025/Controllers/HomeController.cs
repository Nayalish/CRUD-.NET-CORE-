using CRUD2025.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Crud2025Context _context;

        public HomeController(ILogger<HomeController> logger, Crud2025Context context)
        {
            _logger = logger;
            _context = context;
        }




        public IActionResult Index()
        {
            var data = _context.users.ToList();
            return View(data);
        }
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(user data)
        {
            if (ModelState.IsValid)
            {

                _context.Add(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }
            var detail = _context.users.Find(id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, user data)
        {
            if (id != data.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();

            }
            var detail = _context.users.FirstOrDefault(m => m.ID == id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }
            var detail = _context.users.FirstOrDefault(m => m.ID == id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]



        public IActionResult Deleteconfirmed(int id)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'Organization_context.Information' is null");
            }
            var detail = _context.users.Find(id);
            if (detail != null)
            {
                _context.users.Remove(detail);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
