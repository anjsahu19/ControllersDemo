using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControllersDemo.Models
{
    public class Student
    {
        [DisplayName("Roll No")] [Required(AllowEmptyStrings =false,ErrorMessage ="Please add Roll No")]
        public int RollNo { get; set; }

        [DisplayName("Name")] [Required(AllowEmptyStrings = false, ErrorMessage = "Please add Student Name")]
        public string Name { get; set; }

        [DisplayName("Stream")] [Required(AllowEmptyStrings =false, ErrorMessage = "Please add Stream")]
        public string DepartmentName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Please add Total Marks Obtained by Student")]
        [DisplayName("Total Marks Obtained")][Range(1,100,ErrorMessage ="Marks Should Be Between 1 to 100 Only")]
        public int TotalMarks { get; set; }
    }
}