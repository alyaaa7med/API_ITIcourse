using api_lab2.DTOs;
using api_lab2.Models;
using api_lab2.MapperConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;
using api_lab2.Repository;

namespace api_lab2.Controllers
{
    [Route("api/[controller]s")]

    public class StudentController : Controller
    {

        GenericRepo<Student> srepo;
        IMapper mapper;
        public StudentController(GenericRepo<Student> srepo ,IMapper mapper )
        {
            this.srepo = srepo;
            this.mapper = mapper;
        }
        [HttpGet]
        [Produces("application/json")]
      
        public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4, [FromQuery] string? search = null)
        {


            var query = srepo.getall(s=> s.instructor, s=> s.department);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    (s.St_FName != null && s.St_FName.Contains(search)) ||
                    (s.St_LName != null && s.St_LName.Contains(search)) ||
                    (s.department != null && s.department.Dept_Name.Contains(search)) ||
                    (s.instructor != null && s.instructor.Ins_Name.Contains(search))
                );
            }

            var totalRecords = query.Count();

            var pagedStudents = query
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            var stDTOList = mapper.Map<List<StudentDTO>>(pagedStudents);

            var result = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Data = stDTOList
            };

            return Ok(result);
        }

      
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public ActionResult getbyid(int id)
        {
            Student s = srepo.getbyid(id);
            if (s == null) return NotFound();
          
            StudentDTO stDTO = mapper.Map<StudentDTO>(s);
            return Ok(stDTO);
        }

        [HttpPost]
        [Consumes("application/json")]
        public ActionResult post(StudentDTO sdto)
        {
            if (sdto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
          
            var s = mapper.Map<Student>(sdto);
            srepo.Add(s);
            srepo.Save();
            return CreatedAtAction(nameof(getbyid), new { id = s.Id }, sdto);
        }


        [HttpPut("{id:int}")]
        [Consumes("application/json")]

        public IActionResult Update(int id, StudentDTO stdo)
        {
            if (stdo == null)
                return BadRequest();

            var existingStudent = srepo.getbyid(id);  
            if (existingStudent == null)
                return NotFound();

            mapper.Map(stdo, existingStudent);

            srepo.Update(existingStudent);
            srepo.Save();
            return NoContent();
        }



        [HttpDelete("{id:int}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            var student = srepo.getbyid(id);
            if (student == null)
                return NotFound();

            srepo.delete(student);
            srepo.Save();

            var deletedStudentDTO = mapper.Map<StudentDTO>(student);
            return Ok(deletedStudentDTO);
        }





        /*
        [HttpGet]
        [Produces("application/json")]
        public IActionResult getall([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4,[FromQuery] string? search = null)
        {


            var res = db.student.Include(s => s.instructor)
                .Include(s => s.department).AsQueryable(); //must add asqueryable for searching 

            if (!string.IsNullOrEmpty(search))
            {
                //search if matches with  firstname || lastname ||  deptname || instname 
                res = res.Where(s =>
                    (s.St_FName != null && s.St_FName.Contains(search)) ||
                    (s.St_LName != null && s.St_LName.Contains(search)) ||
                    (s.department != null && s.department.Dept_Name.Contains(search))  ||
                    (s.instructor != null && s.instructor.Ins_Name.Contains(search))
                );
            }
            var totalRecords = res.Count();
            var pagedStudents = res
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();


            List<StudentDTO> stDTOList = new List<StudentDTO>();

            foreach (var st_de_in in pagedStudents)
            {
                StudentDTO sDTO = new StudentDTO()
                {
                    //St_Id = st_de_in.St_Id,
                    St_FName = st_de_in.St_FName,
                    St_Address = st_de_in.St_Address,
                    St_Age = st_de_in.St_Age,
                    dept_name = st_de_in.department?.Dept_Name, //must add ? ->null.x => exception 
                    supervisor_name = st_de_in.instructor?.Ins_Name
                };

                stDTOList.Add(sDTO);

            }
            if (stDTOList == null || stDTOList.Count == 0) return NotFound();

            var final_res = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                Data = stDTOList
            };

            return Ok(final_res);
        }
        */
        /*
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult post (StudentDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                var dept = db.department.FirstOrDefault(d => d.Dept_Name == studentDTO.dept_name);
                var inst = db.instructor.FirstOrDefault(i => i.Ins_Name == studentDTO.supervisor_name);
                var maxId = db.student.Max(s => (int?)s.St_Id) ?? 0;

                Student student = new Student();
                student.St_Id = maxId + 1;
                student.St_FName = studentDTO.St_FName;
                student.St_LName = studentDTO.St_LName;
                student.St_Address = studentDTO.St_Address;
                student.St_Age = studentDTO.St_Age;
                student.Dept_Id = dept?.Dept_Id;
                student.St_super = inst?.Ins_Id;

                db.student.Add(student);
                db.SaveChanges();

                return   Ok(studentDTO);

            }
            else
            {
                return BadRequest(studentDTO);
            }

        }
        */

        /*[HttpPost]
        public IActionResult post(Student std)
        {
            if (ModelState.IsValid)
            {
                var student = new Student();
                student.St_FName = std.St_FName;
                student.St_LName = std.St_LName;
                student.St_Address = std.St_Address;
                student.St_Age = std.St_Age;
                student.Dept_Id = std.Dept_Id;
                student.St_super = std.St_super;

                db.Add(student);
                db.SaveChanges();
                return Ok(student);

            }
            else
            {
                return BadRequest(std);
            }
        }*/


    }
}

