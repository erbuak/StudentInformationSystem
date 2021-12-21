using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Areas.StudentPanel.Models;
using StudentInformationSystem.Areas.StudentPanel.ViewModels;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Areas.StudentPanel.Controllers
{
    [Area("StudentPanel")]
    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            int userId = int.Parse(User.Claims.Where(x => x.Type == "UserId").Select(x => x.Value).SingleOrDefault());

            User user = _context.Users.Find(userId);
            Static.IdentityId = (int)user.IdentityId;

            return View();
        }

        public IActionResult CourseRegistration()
        {
            List<Course> selectedCourses;
            List<Course> unselectedCourses;

            Student student = _context.Students.FirstOrDefault(x => x.IdentityId == Static.IdentityId);
            
            if(student.CurriculumId != null)
            {
                int curriculumId = (int)student.CurriculumId;
                int studentId = student.Id;
                int studentCurriculumId = (int)student.CurriculumId;

                var courseRegistrations = _context.CourseRegistrations.Where(x => x.StudentId == studentId);
                selectedCourses = (from course in _context.Courses
                                       join courseRegistration in courseRegistrations
                                       on course.Id equals courseRegistration.CourseId
                                       select course).ToList();

                var courses = from course in _context.Courses.Where(x => x.Status == true)
                              join curriculumCorse in _context.CurriculumCourses.Where(x => x.CurriculumId == studentCurriculumId)
                              on course.Id equals curriculumCorse.CourseId
                              select course;

                unselectedCourses = (from course in courses
                                         where !courseRegistrations.Any(x => course.Id == x.CourseId)
                                         select course).ToList();
            } 
            else
            {
                selectedCourses = null;
                unselectedCourses = null;
            }

            CourseRegistrationViewModel courseRegistrationViewModel = new CourseRegistrationViewModel()
            {
                SelectedCourse = selectedCourses,
                UnselectedCourse = unselectedCourses
            };

            return View(courseRegistrationViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CourseRegistration(int selectedCourse)
        {
            Student student = _context.Students.FirstOrDefault(x => x.IdentityId == Static.IdentityId);
            int studentId = student.Id;

            CourseRegistration newCourseRegistration = new CourseRegistration()
            {
                CourseId = selectedCourse,
                StudentId = studentId
            };

            _context.CourseRegistrations.Add(newCourseRegistration);
            _context.SaveChanges();

            return RedirectToAction("CourseRegistration", "Home");
        }
    }
}
