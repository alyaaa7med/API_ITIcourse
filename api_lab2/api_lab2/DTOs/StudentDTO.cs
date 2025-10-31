using api_lab2.Models;

namespace api_lab2.DTOs
{
    public class StudentDTO
    {
        //same name of student model fields
        public int Id { get; }
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }

        /* the next 2 prob i can not make them in the get request only , i will ignore their values from post / put */
        public string? dept_name { get; set; }
        public string? supervisor_name { get; set; } 
    }
}
