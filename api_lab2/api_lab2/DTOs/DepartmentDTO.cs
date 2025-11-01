using api_lab2.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_lab2.DTOs
{
    public class DepartmentDTO

    {
        //same name of department model fields
        public int Id { get; set; } //if it is only get :  AutoMapper (and the JSON serializer) cannot assign a value to it
        public string? Dept_Name { get; set; }
        public string? Dept_Desc { get; set; }
        public string? Dept_Location { get; set; }

        /* the next prob i can not make it in the get request only , i will ignore its value from post / put */

        public int? num_students { get; set; } 
    }
}
