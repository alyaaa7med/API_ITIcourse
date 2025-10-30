using api_lab2.Models;

namespace api_lab2.DTOs
{
    public class StudentDTO
    {
        public int St_Id { get; }
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }

        public string? dept_name { get; set; }
        public string? supervisor_name { get; set; } 
    }
}
