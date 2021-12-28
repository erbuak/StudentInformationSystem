using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CourseViewModel courseViewModel)
        {

            if (_context.Courses.Any(x => x.Code == courseViewModel.Code))
            {
                ViewBag.ErrorMessage = "Bu ders kodu kullanılıyor. Başka bir ders kodu belirleyin.";
                return View();
            }

            if (ModelState.IsValid)
            {
                Course course = new Course()
                {
                    Code = courseViewModel.Code,
                    Name = courseViewModel.Name,
                    Credit = courseViewModel.Credit,
                    Status = courseViewModel.Status
                };

                _context.Courses.Add(course);
                _context.SaveChanges();

                ViewBag.SuccessMessage = "Ders kayıt işlemi başarılı.";
            }

            return View(courseViewModel);
        }

        public IActionResult Edit(int id)
        {
            Course course = _context.Courses.Find(id);

            CourseUpdateViewModel courseUpdateViewModel = new CourseUpdateViewModel()
            {
                Id = course.Id,
                Code = course.Code,
                Name = course.Name,
                Credit = course.Credit,
                Status = course.Status
            };

            return View(courseUpdateViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(CourseUpdateViewModel courseUpdateViewModel)
        {
            if (_context.Courses.Any(x => x.Id != course.Id && x.Code == courseUpdateViewModel.Code))
            {
                ViewBag.ErrorMessage = "Bu ders kodu kullanılıyor. Başka bir ders kodu belirleyin.";
                return View();
            }

            if(ModelState.IsValid)
            {
                course = _context.Courses.FirstOrDefault(x => x.Id == courseUpdateViewModel.Id);

                course.Code = courseUpdateViewModel.Code;
                course.Name = courseUpdateViewModel.Name;
                course.Credit = courseUpdateViewModel.Credit;
                course.Status = courseUpdateViewModel.Status;

                ViewBag.SuccessMessage = "Ders güncelleme işlemi başarılı.";

                _context.SaveChanges();
            }

            return View();
        }
    }
}
