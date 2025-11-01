using api_lab2.DTOs;
using api_lab2.Models;
using api_lab2.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api_lab2.Controllers
{

    [Route("api/[controller]s")]

    public class StudentDepartmentController : Controller
    {
        public UnitOfWork unitOfWork;
        IMapper mapper;

        public StudentDepartmentController(UnitOfWork unitOfWork, IMapper mapper  ) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper; 
        }

          
        [HttpGet]
        [Produces("application/json")]
        public IActionResult getAll()
        {
            var students_dept = unitOfWork.db.student
                                .Include(sd => sd.department)
                                .ToList();

            var result = mapper.Map<List<UnitStudentDTO>>(students_dept);
            return Ok(result);
        }
        

        [HttpPost]
        [Consumes("application/json")]
        public ActionResult post(UnitStudentDTO UnitStdDto)
        {
            if (UnitStdDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var std = mapper.Map<Student>(UnitStdDto);

            if (std.department != null)
            {
                if (std.department.Id == 0)
                {
                    // New department → insert
                    unitOfWork.Drepo.Add(std.department);
                    unitOfWork.Save();
                }
                else
                {
                    // Existing department → attach (don't insert)
                    unitOfWork.db.Entry(std.department).State = EntityState.Unchanged;
                }

                std.Dept_Id = std.department.Id;
            }

            unitOfWork.Srepo.Add(std);
            unitOfWork.Save();
            return Ok(UnitStdDto);
        }

    }
}
