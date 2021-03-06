﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ControllersDemo.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Roll No")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add Roll No")]
        public int RollNo { get; set; }

        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add Student Name")]
        public string Name { get; set; }

        [DisplayName("Course")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add Stream")]
        public string Stream { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please add Total Marks Obtained by Student")]
        [DisplayName("Total Marks Obtained")]
        [Range(1, 100, ErrorMessage = "Marks Should Be Between 1 to 100 Only")]
        public int TotalMarks { get; set; }
        
        [DisplayName("Department")][IgnoreDataMember]
        public virtual Department StudentDepartment { get; set; }
       // [ForeignKey(name: "Id")]
        public virtual int DepartmentId { get; set; }


    }
}