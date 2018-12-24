using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControllersDemo.Models
{
    // [Bind(Exclude = "Id,AutoId
    [Table("Departments")]
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Department Id")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Department Name.")]
        public string DepartmentName { get; set; }

        [Display(Name = "No of faculties")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter No of faculties Present")]
        [Column(name: "FacultiesPresent")]
        public int Nofaculties { get; set; }

        [Display(Name = "No of Students Present")]
        public virtual List<Student> DepartmentStudents { get; set; }

    }
}