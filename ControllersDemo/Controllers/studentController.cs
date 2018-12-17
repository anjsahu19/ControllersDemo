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
        static IList<Student> students = new List<Student>()
        {
            new Student(){RollNo =1,Name="Kabir",DepartmentName="Information Technology",TotalMarks=75},
            new Student(){RollNo =2,Name="Sania",DepartmentName="Computer Science",TotalMarks=67},
            new Student(){RollNo =3, Name="Deepika",DepartmentName="Biotechnology",TotalMarks=78}
        };

        //static Student student = new Student()
        //{
        //    RollNo = 1,
        //    Name = "Anjali",
        //    DepartmentName = "Information Technology",
        //    TotalMarks = 75
        //};
        // GET: student
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: student/Details/5
        public ActionResult Details(int id)
        {
          
            var student = students.Where(x=> x.RollNo==id).SingleOrDefault();
            return View(student);
        }

        // GET: student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //TryUpdateModel(students, collection);

                string[] rollNo= collection["RollNo"].Split(char.Parse(","));
                string[] name = collection["Name"].Split(char.Parse(","));
                string[] departments= collection["DepartmentName"].Split(char.Parse(","));
                string[] marks= collection["TotalMarks"].Split(char.Parse(","));
                for (int i = 0; i < rollNo.Length; i++)
                {
                    students.Add(new Student()
                    {
                        RollNo = Convert.ToInt32(rollNo[i]),
                        Name = name[i],
                        DepartmentName = departments[i],
                        TotalMarks = Convert.ToInt32(marks[i])
                    });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Edit/5
        public ActionResult Edit(int id)
        {
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
                TryUpdateModel(students.Where(x => x.RollNo == id).SingleOrDefault(), collection);
                return RedirectToAction("Index");
            }
            catch
            {
                var student = students.Where(x => x.RollNo == id).SingleOrDefault();
                return View(student);
            }
        }

        // GET: student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
