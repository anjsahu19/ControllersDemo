using ControllersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ControllersDemo
{
    public class StudentApiController : ApiController
    {

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            using (var StudentDbContext = new StudentModel())
            {
                StudentDbContext.Configuration.ProxyCreationEnabled = false;
                if (StudentDbContext.StudentsDb.Count() == 0)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Data Found");
                
                var response = Request.CreateResponse(HttpStatusCode.OK, StudentDbContext.StudentsDb.ToList());
                return response;
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            using (var StudentDbContext = new StudentModel())
            {
                StudentDbContext.Configuration.ProxyCreationEnabled = false;
                var student = StudentDbContext.StudentsDb.Where(x => x.RollNo == id).FirstOrDefault();

                if (student == null)
                    return BadRequest("Student Not Found!");
                return Ok(student);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Student value)
        {
            using (var StudentDbContext = new StudentModel())
            {
                if (value == null)
                {
                    return Content(HttpStatusCode.BadRequest, "No Data Found!");
                }

                StudentDbContext.StudentsDb.Add(value);
                StudentDbContext.Entry(value).State = System.Data.Entity.EntityState.Added;
                StudentDbContext.SaveChanges();
                return Content(HttpStatusCode.Created,
                    string.Format("{0} added in department {1}",
                    value.Name,
                    StudentDbContext.DepartmentsDb.Where(x => x.Id == value.DepartmentId).Select(x => x.DepartmentName).FirstOrDefault()));
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]string Name)
        {
            if (ModelState.IsValid)
                return BadRequest("Invalid Data");     
            using (var StudentDbContext = new StudentModel())
            {
                if (string.IsNullOrEmpty(Name) || id <= 0)               
                    return Content(HttpStatusCode.NotModified, "Name or rollno not passed");
                
                var student = StudentDbContext.StudentsDb.Where(x => x.RollNo == id).FirstOrDefault();
                if (student == null)
                    return Content(HttpStatusCode.NotFound, string.Format("Student with rollno {0} not found", id));
                StudentDbContext.StudentsDb.Where(x => x.RollNo == id).FirstOrDefault().Name = Name;
                StudentDbContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
                StudentDbContext.SaveChanges();
                return Content(HttpStatusCode.OK, string.Format("rollNo {0} name modified", Name));
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            using (var StudentDbContext = new StudentModel())
            {
                var student = StudentDbContext.StudentsDb.Where(x => x.RollNo == id).FirstOrDefault();
                if (student == null)
                    return NotFound();
                StudentDbContext.StudentsDb.Remove(student);
                StudentDbContext.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                StudentDbContext.SaveChanges();
                return Content(HttpStatusCode.OK, String.Format("Rollno {0} deleted Successfully!", id));
            }

        }
    }
}