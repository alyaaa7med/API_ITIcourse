using api_lab2.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_lab2.DTOs
{
    public class DepartmentDTO
    {
        public int Dept_Id { get; set;  }
        public string? Dept_Name { get; set; }
        public string? Dept_Desc { get; set; }
        public string? Dept_Location { get; set; }
        //public int? Dept_Manager { get; set; }
        //public DateOnly? Manager_hireDate { get; set; }
        public int? num_students { get; set; }
    }
}
