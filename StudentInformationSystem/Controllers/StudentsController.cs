using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;
using StudentInformationSystem.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInformationSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.Include(x => x.Identity).OrderByDescending(x => x.Id).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(x => x.Username == studentViewModel.Username))
                {
                    ViewBag.ErrorMessage = "Bu kullanıcı adı kullanılıyor. Başka bir kullanıcı adı belirleyin.";
                    return View();
                }

                Contact contact = new Contact
                {
                    Address = studentViewModel.Address,
                    City = studentViewModel.City,
                    District = studentViewModel.District,
                    Email = studentViewModel.Email,
                    GSM = studentViewModel.GSM
                };

                _context.Contacts.Add(contact);
                _context.SaveChanges();
                int contactId = contact.Id;

                Identity identity = new Identity()
                {
                    TcNo = studentViewModel.TcNo,
                    Name = studentViewModel.Name,
                    Surname = studentViewModel.Surname,
                    DateOfBirth = studentViewModel.DateOfBirth,
                    PlaceOfBirth = studentViewModel.PlaceOfBirth,
                    ContactId = contactId
                };

                _context.Identities.Add(identity);
                _context.SaveChanges();
                int identitiesId = identity.Id;

                User user = new User()
                {
                    Username = studentViewModel.Username,
                    Password = studentViewModel.Password,
                    Type = true,
                    IdentityId = identitiesId
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                Student student = new Student()
                {
                    IdentityId = identitiesId,
                    StudentNumber = GenerateStudentNumber()
                };

                _context.Students.Add(student);
                _context.SaveChanges();

                ViewBag.SuccessMessage = "Öğrenci kayıt işlemi başarılı.";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
                return NotFound();

            Identity identity = _context.Identities.FirstOrDefault(x => x.Id == id);

            if (identity == null)
                return NotFound();

            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == identity.ContactId);

            StudentUpdateViewModel studentUpdateViewModel = new StudentUpdateViewModel()
            {
                IdentityId = identity.Id,
                Name = identity.Name,
                Surname = identity.Surname,
                TcNo = identity.TcNo,
                PlaceOfBirth = identity.PlaceOfBirth,
                DateOfBirth = identity.DateOfBirth,
                ContactId = contact.Id,
                Address = contact.Address,
                City = contact.City,
                District = contact.District,
                Email = contact.Email,
                GSM = contact.GSM
            };

            return View(studentUpdateViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(StudentUpdateViewModel studentUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                Identity identity = _context.Identities.FirstOrDefault(x => x.Id == studentUpdateViewModel.IdentityId);

                identity.Name = studentUpdateViewModel.Name;
                identity.Surname = studentUpdateViewModel.Surname;
                identity.TcNo = studentUpdateViewModel.TcNo;
                identity.PlaceOfBirth = studentUpdateViewModel.PlaceOfBirth;
                identity.DateOfBirth = studentUpdateViewModel.DateOfBirth;

                Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == studentUpdateViewModel.ContactId);

                contact.Address = studentUpdateViewModel.Address;
                contact.City = studentUpdateViewModel.City;
                contact.District = studentUpdateViewModel.District;
                contact.Email = studentUpdateViewModel.Email;
                contact.GSM = studentUpdateViewModel.GSM;

                _context.SaveChanges();

                ViewBag.SuccessMessage = "Öğrenci güncelleme işlemi başarılı.";
            }

            return View();
        }

        public IActionResult CurriculumToStudent(int id)
        {
            string currentCurriculumName;
            Student student = _context.Students.FirstOrDefault(x => x.IdentityId == id);

            if(_context.Curriculums.FirstOrDefault(x => x.Id == student.CurriculumId) == null)
            {
                currentCurriculumName = "Henüz müfredat atanmamış.";
            } 
            else
            {
                currentCurriculumName = _context.Curriculums.FirstOrDefault(x => x.Id == student.CurriculumId).Name;
            }

            CurriculumToStudentViewModel curriculumToStudentViewModel = new CurriculumToStudentViewModel()
            {
                StudentNumber = student.StudentNumber,
                CurrentCurriculumId = student.CurriculumId,
                CurrentCurriculumName = currentCurriculumName,
                AllCurriculms = _context.Curriculums.ToList()
            };
            return View(curriculumToStudentViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CurriculumToStudent(int selectedCurriculum, int StudentNumber)
        {
            Student student = _context.Students.Include(x => x.Curriculum).FirstOrDefault(x => x.StudentNumber == StudentNumber);

            student.CurriculumId = selectedCurriculum;

            _context.SaveChanges();

            CurriculumToStudentViewModel curriculumToStudentViewModel = new CurriculumToStudentViewModel()
            {
                StudentNumber = StudentNumber,
                CurrentCurriculumId = selectedCurriculum,
                CurrentCurriculumName = _context.Curriculums.FirstOrDefault(x => x.Id == selectedCurriculum).Name,
                AllCurriculms = _context.Curriculums.ToList(),
            };

            ViewBag.SuccessMessage = "Müfredat atama işlemi başarılı.";

            return View(curriculumToStudentViewModel);
        }

        public IActionResult StudentCourseRegistrations(int id)
        {
            Student student = _context.Students.FirstOrDefault(x => x.IdentityId == id);
            int curriculumId = (int)student.CurriculumId;
            int studentId = student.Id;
            int studentCurriculumId = (int)student.CurriculumId;

            var courseRegistrations = _context.CourseRegistrations.Where(x => x.StudentId == studentId);
            var selectedCourses = (from course in _context.Courses
                                   join courseRegistration in courseRegistrations
                                   on course.Id equals courseRegistration.CourseId
                                   select course).ToList();

            StudenCourseRegistrationsViewModel studenCourseRegistrationsViewModel = new StudenCourseRegistrationsViewModel()
            {
                SelectedCourses = selectedCourses,
                Student = student
            };

            return View(studenCourseRegistrationsViewModel);
        }

        public IActionResult CancelStudentCourseRegistration(int studentId, int courseId)
        {
            CourseRegistration courseRegistration = _context.CourseRegistrations.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
            _context.CourseRegistrations.Remove(courseRegistration);
            _context.SaveChanges();

            Student student = _context.Students.Find(studentId);

            return RedirectToAction("StudentCourseRegistrations", "Students", new { id = student.IdentityId});
        }

        private int GenerateStudentNumber()
        {
            Random rnd = new Random(); 
            int number = rnd.Next(10000000, 99999999);
            if (!_context.Students.Any(x => x.StudentNumber == number))
                return number;
            else return GenerateStudentNumber();
        }
    }
}
