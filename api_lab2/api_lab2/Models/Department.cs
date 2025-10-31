using api_lab2.Repository;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_lab2.Models
{
    public class Department : IentityId
    {
        [Key]
        [Column("Dept_Id")]

        public int Id { get; set; }
        public string? Dept_Name { get; set; }
        public string? Dept_Desc { get; set; }
        public string? Dept_Location { get; set; }
        public int? Dept_Manager { get; set; }
        public DateOnly? Manager_hireDate { get; set; }


        //navigation property — it’s not stored in the DB
        //it is for linq => include = join 
        public List<Student>? students { get; set; }
    }
}
