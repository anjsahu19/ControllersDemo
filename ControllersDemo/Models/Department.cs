using System.ComponentModel.DataAnnotations;

namespace ControllersDemo.Models
{
    // [Bind(Exclude = "Id,AutoId")]
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Department Id")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Department Name.")]
        public string DepartmentName { get; set; }

        [Display(Name ="No of Students")] [Required(AllowEmptyStrings =false, ErrorMessage ="Please Enter No of Students Present")]
        public int  StudentsPresent { get; set; }


    }
}