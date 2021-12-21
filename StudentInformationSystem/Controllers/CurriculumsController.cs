using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels.Curriculums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CurriculumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurriculumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Curriculums.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(CurriculumViewModel curriculumViewModel)
        {
            if (ModelState.IsValid)
            {
                Curriculum curriculum = new Curriculum
                {
                    Name = curriculumViewModel.Name
                };

                _context.Curriculums.Add(curriculum);
                _context.SaveChanges();

                ViewBag.SuccessMessage = "Müfredat kayıt işlemi başarılı.";
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Curriculum curriculum = _context.Curriculums.FirstOrDefault(x => x.Id == id);

            CurriculumUpdateViewModel curriculumUpdateViewModel = new CurriculumUpdateViewModel()
            {
                Id = curriculum.Id,
                Name = curriculum.Name
            };

            if (curriculum == null)
                return NotFound();

            if (id == null)
                return NotFound();

            return View(curriculumUpdateViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(CurriculumUpdateViewModel curriculumUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Curriculum curriculum = _context.Curriculums.FirstOrDefault(x => x.Id == curriculumUpdateViewModel.Id);

                curriculum.Name = curriculumUpdateViewModel.Name;

                _context.SaveChanges();

                ViewBag.SuccessMessage = "Müfredat güncelleme işlemi başarılı.";
            }

            return View();
        }

        public IActionResult CurriculumCourses(int id)
        {
            var query = from course in _context.Courses
                        join curriculumCourse in _context.CurriculumCourses.Where(x => x.CurriculumId == id)
                        on course.Id equals curriculumCourse.CourseId
                        select new CurriculumCoursesViewModel()
                        {
                            CirculumCorsesId = curriculumCourse.Id,
                            CourseId = course.Id,
                            CourseName = course.Name,
                        };

            var unselectedCoursesQuery = from course in _context.Courses
                                         where !_context.CurriculumCourses.Where(x => x.CurriculumId == id).Any(x => course.Id == x.CourseId)
                                         select new Course()
                                         {
                                             Id = course.Id,
                                             Code = course.Code,
                                             Name = course.Name,
                                             Status = course.Status,
                                             Credit = course.Credit
                                         };

            ViewData["UnselectedCourses"] = unselectedCoursesQuery.ToList();
            ViewData["CurriculumId"] = id;
            ViewData["CurriculumName"] = _context.Curriculums.Find(id).Name;

            return View(query.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CurriculumCourses(int id, int selectedCourse)
        {
            CurriculumCourse newcurriculumCourse = new CurriculumCourse()
            {
                CurriculumId = id,
                CourseId = selectedCourse
            };

            _context.CurriculumCourses.Add(newcurriculumCourse);
            _context.SaveChanges();

            return RedirectToAction("CurriculumCourses", "Curriculums");
        }

        public IActionResult CurriculumCourseDelete(int curriculumCourseId, int curriculumId)
        {
            CurriculumCourse curriculumCourse = _context.CurriculumCourses.Find(curriculumCourseId);
            _context.CurriculumCourses.Remove(curriculumCourse);
            _context.SaveChanges();
            return RedirectToAction("CurriculumCourses", "Curriculums", new { @id = curriculumId });
        }
    }
}
