using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ControllersDemo.Models
{
    public class Student
    {
        [DisplayName("Roll No")]
        public int RollNo { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Stream")]
        public string DepartmentName { get; set; }
        [DisplayName("Total Marks Obtained")]
        public int TotalMarks { get; set; }
    }
}