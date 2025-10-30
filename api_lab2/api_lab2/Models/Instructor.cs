using System.ComponentModel.DataAnnotations;

namespace api_lab2.Models
{
    public class Instructor
    {
        [Key]
       public int Ins_Id { get; set; }
       public string?   Ins_Name { get; set; }
       public string?   Ins_Degree { get; set; }
       public int?  Salary { get; set; }
       public int? Dept_Id { get; set; }
    }
}
