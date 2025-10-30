using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_lab2.Models
{
    public class Department
    {
        [Key]
        [Column("Dept_Id")]

        public int Id  { get; set; }
        public string? Dept_Name { get; set; }
        public string? Dept_Desc { get; set; }
        public string? Dept_Location { get; set; }
        public int?    Dept_Manager { get; set; } 
        public DateOnly? Manager_hireDate { get; set; }

        
        //public int? St_Id { get; set; }

        //[ForeignKey("St_Id")]
        public List<Student>? students { get; set; }

    }
}
