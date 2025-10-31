using api_lab2.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_lab2.Models
{
    public class Student: IentityId
    {
        [Column("St_Id")]
        [Key]

        public int Id { get; set; } //will hides the inherited one => do not worry 
        public string? St_FName { get; set; }
        public string? St_LName { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }

       

        //Foreign key properties must exist
        public int? Dept_Id { get; set; }
        public int? St_super { get; set; }

        
        //navigation property — it’s not stored in the DB
        //it is for linq => include = join 
        [ForeignKey("Dept_Id")]
        public Department? department { get; set; } // 1:1 or many-to-1

        [ForeignKey("St_super")]
        public Instructor? instructor { get; set; } // 1:1 or many-to-1
       


    }
}
