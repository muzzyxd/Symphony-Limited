using Microsoft.AspNetCore.Mvc;
using Symphony_Limited.Data;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Symphony_Limited.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CourseController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> ShowCourse()
        {
            var subject = await _context.Subjects.OrderByDescending(p => p.Subject_Id).ToListAsync();
            return View(subject);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(SubjectDto subjectDto)
        {
            if (subjectDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "this image file is req");
            }

            if (!ModelState.IsValid)
            {
                return View(subjectDto);
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(subjectDto.ImageFile!.FileName);

            string SubjectImgName = _environment.WebRootPath + "/images/" + newFileName;
            using (var stream = System.IO.File.Create(SubjectImgName))
            {
                subjectDto.ImageFile.CopyTo(stream);

            }

            Subject subject = new Subject()
            {
                SubjectName = subjectDto.SubjectName,
                SubjectDescription = subjectDto.SubjectDescription,
                Duration = subjectDto.Duration,
                Fees = subjectDto.Fees,
                SubjectImgName = newFileName,
                Created_at = DateTime.Now

            };
            _context.Subjects.Add(subject);
            _context.SaveChanges();


            return RedirectToAction("ShowCourse");
        }

        public IActionResult EditCourse(int id)
        {
            var subject = _context.Subjects.Find(id);

            if (subject == null)
            {
                return RedirectToAction("ShowCourse","Course");
            }

            var subjectDto = new SubjectDto()
            {
                SubjectName = subject.SubjectName,
                SubjectDescription = subject.SubjectDescription,
                Duration = subject.Duration,
                Fees = subject.Fees,
            };

            ViewData["Subject_Id"] = subject.Subject_Id;
            ViewData["SubjectImgName"] = subject.SubjectImgName;
            ViewData["Created_At"] = subject.Created_at.ToString("MM/dd/yyyy");

            return View(subjectDto);
        }

        [HttpPost]
        public IActionResult EditCourse(int id, SubjectDto subjectDto)
        {
            var subject = _context.Subjects.Find(id);

            if (subject == null)
            {
                return RedirectToAction("ShowCourse", "Course");
            }
            if (!ModelState.IsValid)
            {
                ViewData["Subject_Id"] = subject.Subject_Id;
                ViewData["SubjectImgName"] = subject.SubjectImgName;
                ViewData["Created_at"] = subject.Created_at.ToString("dd/MM/yyyy");

                return View(subjectDto);
            }

            string newFileName = subject.SubjectImgName;
            if(subjectDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(subjectDto.ImageFile.FileName);

                string SubjectImgName = _environment.WebRootPath + "/images/" + newFileName;
                using (var stream = System.IO.File.Create(SubjectImgName))
                {
                    subjectDto.ImageFile.CopyTo(stream);

                }

                string oldSubjectImgName = _environment.WebRootPath + "/images/" + subject.SubjectImgName;
                System.IO.File.Delete(oldSubjectImgName);
            }

            subject.SubjectName = subjectDto.SubjectName;
            subject.SubjectDescription = subjectDto.SubjectDescription;
            subject.Duration = subjectDto.Duration;
            subject.Fees = subjectDto.Fees;
            subject.SubjectImgName = newFileName;

            _context.SaveChanges();

            return RedirectToAction("ShowCourse", "Course");
        }

        public IActionResult DeleteCourse(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return RedirectToAction("ShowCourse","Course");
            }
            string SubjectImgName = _environment.WebRootPath + "/images/" + subject.SubjectImgName;
            System.IO.File.Delete(SubjectImgName);

            _context.Subjects.Remove(subject);
            _context.SaveChanges(true);

            return RedirectToAction("ShowCourse", "Course");
        }


    }
 }
    
