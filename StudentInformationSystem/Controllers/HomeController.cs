using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;
using System.Diagnostics;
using System.Linq;

namespace StudentInformationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if(User.IsInRole("Student"))
            {
                return RedirectToAction("Index", "Home", new { area = "StudentPanel" });
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListIdentities()
        {
            return View(_context.Identities.ToList());
        }

        public IActionResult ListContacts()
        {
            return View(_context.Contacts.ToList());
        }

        public IActionResult ListUsers()
        {
            return View(_context.Users.Include(x => x.Identity).ToList());
        }
    }
}
