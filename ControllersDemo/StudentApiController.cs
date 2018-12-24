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
        public IHttpActionResult Get()
        {
            using (var StudentDbContext = new StudentModel())
            {
                StudentDbContext.Configuration.ProxyCreationEnabled = false;
                if (StudentDbContext.StudentsDb.Count() < 0)
                    return NotFound();
                return Ok(StudentDbContext.StudentsDb);
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
        public IHttpActionResult Post([FromUri]Student value)
        {
            using (var StudentDbContext = new StudentModel())
            {
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
      
        public void Put(int id, [FromUri]string Name)
        {
            using (var StudentDbContext = new StudentModel())
            {
                StudentDbContext.StudentsDb.Where(x => x.RollNo == id).FirstOrDefault().Name = Name;
                StudentDbContext.SaveChanges();
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
                return Content(HttpStatusCode.OK,String.Format("Rollno {0} deleted Successfully!", id));
            }
           
        }
    }
}