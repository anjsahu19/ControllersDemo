using ControllersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersDemo.Controllers
{
    public class studentController : Controller
    {
        //static IList<Student> students = new List<Student>()
        //{
        //    new Student(){RollNo =1,Name="Kabir",Stream="Information Technology",TotalMarks=75},
        //    new Student(){RollNo =2,Name="Sania",Stream="Computer Science",TotalMarks=67},
        //    new Student(){RollNo =3, Name="Deepika",Stream="Biotechnology",TotalMarks=78}
        //};
        StudentModel StudentDbContext = new StudentModel();

        // GET: student
        public ActionResult Index()
        {
            ApiCall apiCall = new ApiCall("http://localhost:49552/");
            var students = apiCall.GetStudents("api/StudentApi/Get/");
            //var students = StudentDbContext.StudentsDb.ToList();
            return View(students);
        }

        // GET: student/Details/5
        public ActionResult Details(int id)
        {
            //var students = StudentDbContext.StudentsDb.ToList();
            ApiCall apiCall = new ApiCall("http://localhost:49552/");
            var students = apiCall.GetStudents("api/StudentApi/Get/");
            var student = students.Where(x => x.RollNo == id).SingleOrDefault();
            return View(student);
        }

        // GET: student/Create
        public ActionResult Create()
        {
            ViewBag.Departments = StudentDbContext.DepartmentsDb.ToList();
            return View();
        }

        // POST: student/Create
        [HttpPost]
        public ActionResult Create(Student obj)
        {
            try
            {

                StudentDbContext.StudentsDb.Add(obj);
                StudentDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: student/Edit/5
        public ActionResult Edit(int id)
        {
            var students = StudentDbContext.StudentsDb.ToList();
            var student = students.Where(x => x.RollNo == id).SingleOrDefault();
            return View(student);
        }

        // POST: student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //   var student = students.Where(x => x.RollNo == id).SingleOrDefault();
                // var students = StudentDbContext.StudentsDb.ToList();
                TryUpdateModel(StudentDbContext.StudentsDb.ToList().Where(x => x.RollNo == id).SingleOrDefault(), collection);
                StudentDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var students = StudentDbContext.StudentsDb.ToList();

                var student = students.Where(x => x.RollNo == id).SingleOrDefault();
                return View(student);
            }
        }

        // GET: student/Delete/5
        public ActionResult Delete(int id)
        {
            var students = StudentDbContext.StudentsDb.ToList();
            var student = students.Where(x => x.RollNo == id).SingleOrDefault();
            return View(student);
        }

        // POST: student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //var students = StudentDbContext.StudentsDb.ToList();
                var s = StudentDbContext.StudentsDb.ToList().Where(x => x.RollNo == id).FirstOrDefault();
                StudentDbContext.StudentsDb.Remove(s);
                StudentDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
