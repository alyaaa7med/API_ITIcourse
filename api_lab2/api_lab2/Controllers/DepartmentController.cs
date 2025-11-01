using api_lab2.DTOs;
using api_lab2.Models;
using api_lab2.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_lab2.Controllers
{
    [Route("api/[controller]s")]
    public class DepartmentController : Controller
    {
        GenericRepo<Department> drepo;
        IMapper mapper;

        public DepartmentController(GenericRepo<Department> drepo , IMapper mapper)
        {
            this.drepo = drepo;
            this.mapper = mapper;
        }


        [HttpGet]
        [Produces("application/json")]
        [EndpointSummary("select all departments ")]
        [ProducesResponseType(200,Type = typeof(DepartmentDTO))]
        public IActionResult GetAll()
        {
            var query = drepo.getall(d => d.students);


            var deptDTOList = mapper.Map<List<DepartmentDTO>>(query);

            return Ok(deptDTOList);
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [EndpointSummary("select one department by id ")]
        [ProducesResponseType(200, Type = typeof(DepartmentDTO))]
        [ProducesResponseType(404, Type = typeof(void))]

        public ActionResult getbyid(int id)
        {
            Department d = drepo.getbyid(id);
            if (d == null) return NotFound();

            DepartmentDTO deptDTO = mapper.Map<DepartmentDTO>(d);
            return Ok(deptDTO);
        }

        [HttpPost]
        [Consumes("application/json")]
        [EndpointSummary("create new department  ")]

        public ActionResult post(DepartmentDTO depdto)
        {
            if (depdto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            
            var department = mapper.Map<Department>(depdto);
            drepo.Add(department);
            drepo.Save();

            var createdDTO = mapper.Map<DepartmentDTO>(department);

            return CreatedAtAction(nameof(getbyid), new { id = department.Id }, createdDTO);


        }


        [HttpPut("{id:int}")]
        [Consumes("application/json")]
        [EndpointSummary("update existing department by id  ")]

        public IActionResult Update(int id, DepartmentDTO deptdto)
        {
            if (deptdto == null)
                return BadRequest();

            var dep = drepo.getbyid(id);
            if (dep == null)
                return NotFound();

            mapper.Map(deptdto, dep);

            drepo.Update(dep);
            drepo.Save();

            return NoContent();
        }



        [HttpDelete("{id:int}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EndpointSummary("delete department by id ")]
        [ProducesResponseType(200, Type = typeof(DepartmentDTO))]
        public IActionResult Delete(int id)
        {
            var dept = drepo.getbyid(id);
            if (dept == null)
                return NotFound();

            drepo.delete(dept);
            drepo.Save();

            var deldept = mapper.Map<DepartmentDTO>(dept);
            return Ok(deldept);
        }




    }
}


