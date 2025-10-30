using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_lab2.Models
{
    public class Student
    {
        [Key]
        public int St_Id { get; set; }
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }

        //public int? Dept_Id { get; set; }
        //public int? St_super { get; set; }



        //Foreign key properties must exist
        public int? Dept_Id { get; set; }
        public int? St_super { get; set; }

        // Navigation properties
        [ForeignKey("Dept_Id")]
        public Department? department { get; set; } // 1:1 or many-to-1

        [ForeignKey("St_super")]
        public Instructor? instructor { get; set; } // 1:1 or many-to-1
       


    }
}
