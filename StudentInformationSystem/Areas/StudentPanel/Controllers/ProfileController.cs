using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Areas.StudentPanel.Models;
using StudentInformationSystem.Models;
using System.Linq;

namespace StudentInformationSystem.Areas.StudentPanel.Controllers
{
    [Area("StudentPanel")]
    [Authorize(Roles = "Student")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly User user;
        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
            user = _context.Users.Find(Static.IdentityId);
        }

        public IActionResult IdentityInfo()
        {          
            Identity ıdentity = _context.Identities.FirstOrDefault(x => x.Id == user.IdentityId);

            return View(ıdentity);
        }

        public IActionResult ContactInfo()
        {
            int contactId = _context.Identities.FirstOrDefault(x => x.Id == user.IdentityId).ContactId;
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == contactId);
            return View(contact);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ContactInfo(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "Güncelleme işlemi başarılı.";

            return View();
        }
    }
}
