using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data
{
    public class Dataİnitializer
    {
        public static void DataSeed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Contacts.Any())
                {
                    context.Contacts.AddRange(
                        new Contact()
                        {
                            Address = "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6",
                            City = "ANKARA",
                            District = "YENİMAHALLE",
                            Email = "abc@hotmail.com",
                            GSM = 5332342342
                        },
                        new Contact()
                        {
                            Address = "KUŞADASI SOK. NO:123 KARAAĞAÇ",
                            City = "ANKARA",
                            District = "ÇANKAYA",
                            Email = "def@gmail.com",
                            GSM = 5437657567
                        },
                        new Contact()
                        {
                            Address = "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51",
                            City = "ANKARA",
                            District = "KEÇİÖREN",
                            Email = "ghi@abc.com",
                            GSM = 5305464646
                        },
                        new Contact()
                        {
                            Address = "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1",
                            City = "ANKARA",
                            District = "PURSAKLAR",
                            Email = "mno@xyz.com",
                            GSM = 5555424245
                        },
                        new Contact()
                        {
                            Address = "AHMET HAMDİ SOK. NO:19/15",
                            City = "ANKARA",
                            District = "SİNCAN",
                            Email = "prs@hotmail.com",
                            GSM = 5302908432
                        },
                        new Contact()
                        {
                            Address = "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3",
                            City = "ANKARA",
                            District = "POLATLI",
                            Email = "klm@outlook.com",
                            GSM = 5408932042
                        }
                    );

                    context.SaveChanges();
                }       
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Identities.Any())
                {
                    context.Identities.AddRange(
                        new Identity()
                        {
                            TcNo = 45456747611,
                            Name = "Hasan",
                            Surname = "Ersoy",
                            PlaceOfBirth = "Kayseri",
                            DateOfBirth = new DateTime(1983, 10, 11),
                            ContactId = 4
                        },
                        new Identity()
                        {
                            TcNo = 67967856634,
                            Name = "Mehmet",
                            Surname = "Yılmaz",
                            PlaceOfBirth = "Adana",
                            DateOfBirth = new DateTime(2000, 3, 12),
                            ContactId = 1
                        },
                        new Identity()
                        {
                            TcNo = 72347322958,
                            Name = "Ahmet",
                            Surname = "Ünal",
                            PlaceOfBirth = "Ankara",
                            DateOfBirth = new DateTime(2001, 6, 14),
                            ContactId = 6
                        },
                        new Identity()
                        {
                            TcNo = 97850348520,
                            Name = "Mustafa",
                            Surname = "Işık",
                            PlaceOfBirth = "Sivas",
                            DateOfBirth = new DateTime(2000, 12, 21),
                            ContactId = 3
                        },
                        new Identity()
                        {
                            TcNo = 32756874239,
                            Name = "Ayşe",
                            Surname = "Erdoğan",
                            PlaceOfBirth = "Uşak",
                            DateOfBirth = new DateTime(2001, 3, 4),
                            ContactId = 5
                        },
                        new Identity()
                        {
                            TcNo = 45456747611,
                            Name = "Fatma",
                            Surname = "Korkmaz",
                            PlaceOfBirth = "Kütahya",
                            DateOfBirth = new DateTime(2001, 1, 1),
                            ContactId = 2
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User()
                        {
                            Username = "hasan.ersoy",
                            Password = "Haser1.",
                            Type = false,
                            IdentityId = 1
                        },
                        new User()
                        {
                            Username = "mehmet.yilmaz",
                            Password = "Mehyil6!",
                            Type = true,
                            IdentityId = 2
                        },
                        new User()
                        {
                            Username = "ahmet.unal",
                            Password = "Ahun23+",
                            Type = true,
                            IdentityId = 3
                        },
                        new User()
                        {
                            Username = "mustafa.isik",
                            Password = "Musi64%",
                            Type = true,
                            IdentityId = 4
                        },
                        new User()
                        {
                            Username = "ayse.erdogan",
                            Password = "Ayer33.",
                            Type = true,
                            IdentityId = 5
                        },
                        new User()
                        {
                            Username = "fatma.korkmaz",
                            Password = "Fatkor12%",
                            Type = true,
                            IdentityId = 6
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Curriculums.Any())
                {
                    context.Curriculums.AddRange(
                        new Curriculum()
                        {
                            Name = "BilgMuh_Mufredat"
                        },
                        new Curriculum()
                        {
                            Name = "GrafikMuh_Mufredat"
                        },
                        new Curriculum()
                        {
                            Name = "IngDilEdebiyat_Muf"
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student()
                        {
                            StudentNumber = 27482379,
                            IdentityId = 3,
                            CurriculumId = 1
                        },
                        new Student()
                        {
                            StudentNumber = 23462368,
                            IdentityId = 5,
                            CurriculumId = 1
                        },
                        new Student()
                        {
                            StudentNumber = 34565479,
                            IdentityId = 6,
                            CurriculumId = 2
                        },
                        new Student()
                        {
                            StudentNumber = 53456346,
                            IdentityId = 2,
                            CurriculumId = 2
                        },
                        new Student()
                        {
                            StudentNumber = 34674575,
                            IdentityId = 4,
                            CurriculumId = 3
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(
                        new Course()
                        {
                            Code = "HUM101",
                            Name = "Türk Demokrasi Tarihi",
                            Status = true,
                            Credit = 5
                        },
                        new Course()
                        {
                            Code = "MATH102",
                            Name = "Calculus 2",
                            Status = false,
                            Credit = 6
                        },
                        new Course()
                        {
                            Code = "MATE103",
                            Name = "Metalurjiye Giriş ",
                            Status = false,
                            Credit = 6
                        },
                        new Course()
                        {
                            Code = "GRA105",
                            Name = "Grafik Dizayn",
                            Status = true,
                            Credit = 5
                        },
                        new Course()
                        {
                            Code = "CMPE201",
                            Name = "Bilgisayar Teknolojileri",
                            Status = true,
                            Credit = 4
                        },
                        new Course()
                        {
                            Code = "ENG102",
                            Name = "İngilizce 2",
                            Status = true,
                            Credit = 4
                        },
                        new Course()
                        {
                            Code = "MATH201",
                            Name = "İleri Calculus ",
                            Status = true,
                            Credit = 6
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.CurriculumCourses.Any())
                {
                    context.CurriculumCourses.AddRange(
                        new CurriculumCourse()
                        {
                            CurriculumId = 1,
                            CourseId = 2
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 1,
                            CourseId = 5
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 1,
                            CourseId = 6
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 1,
                            CourseId = 7
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 1
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 2
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 3
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 4
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 6
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 2,
                            CourseId = 7
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 3,
                            CourseId = 1
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 3,
                            CourseId = 4
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 3,
                            CourseId = 5
                        },
                        new CurriculumCourse()
                        {
                            CurriculumId = 3,
                            CourseId = 6
                        }
                    );

                    context.SaveChanges();
                }
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.CourseRegistrations.Any())
                {
                    context.CourseRegistrations.AddRange(
                        new CourseRegistration()
                        {
                            StudentId = 3,
                            CourseId = 3,
                            CreatedDate = new DateTime(2021, 11, 04)
                        },
                        new CourseRegistration()
                        {
                            StudentId = 4,
                            CourseId = 6,
                            CreatedDate = new DateTime(2021, 11, 04)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
