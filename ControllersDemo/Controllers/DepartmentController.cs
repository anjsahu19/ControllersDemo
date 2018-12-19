using ControllersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersDemo.Controllers
{
    public class DepartmentController : Controller
    {
        //    static IList<Department> Departments = new List<Department>()
        //    {
        //        new Department(){DepartmentName ="Information Technology",StudentsPresent=1},
        //        new Department(){DepartmentName = "Physics",StudentsPresent =2},
        //        new Department(){DepartmentName = "Pharmacy", StudentsPresent=4}
        //    };

        StudentModel StudentDbContext = new StudentModel();
        // GET: Department
        public ActionResult Index()
        {
            var Departments = StudentDbContext.DepartmentsDb.ToList();
            return View(Departments);
        }

    }
}