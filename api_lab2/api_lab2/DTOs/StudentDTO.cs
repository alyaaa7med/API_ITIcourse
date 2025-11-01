using api_lab2.Models;
using Azure.Core;

namespace api_lab2.DTOs
{
    public class StudentDTO
    {
        //same name of student model fields
        public int Id { get; set; }
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }


        /* the next 2 prob i can not make them in the get request only , i will ignore their values from post / put */
        /* if i need to add it using automapper , i can not as dept_name & supervisor_name not in model 
      
        
        */
        public string? dept_name { get; set; }
        public string? supervisor_name { get; set; }

        
        
    }
}
