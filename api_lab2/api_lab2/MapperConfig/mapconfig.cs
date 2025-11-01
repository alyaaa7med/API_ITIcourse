
using api_lab2.Controllers;
using api_lab2.DTOs;
using api_lab2.Models;
using AutoMapper;
namespace api_lab2.MapperConfig
{
    public class mapconfig : Profile
    {

        /* works field by field in dto + model if they are of the same name 
           but if not same will not mapped */
        public mapconfig()
        {
            CreateMap<Student, StudentDTO>()

            .ForMember(dest => dest.dept_name, opt => opt.MapFrom(src => src.department != null ? src.department.Dept_Name : null))
            .ForMember(dest => dest.supervisor_name, opt => opt.MapFrom(src => src.instructor != null ? src.instructor.Ins_Name : null))
            .ReverseMap();



            CreateMap<Department, DepartmentDTO>()
            .ForMember(dest => dest.num_students, opt => opt.MapFrom(src => src.students != null ? src.students.Count : 0))
            .ReverseMap();



            //must be added so that auto map can use it when mapping student with department info 
            CreateMap<Department, UnitDepartmentDTO>().ReverseMap();

            CreateMap<Student, UnitStudentDTO>()
             .ForMember(dest => dest.ddto, opt => opt.MapFrom(src => src.department))
             .ReverseMap();

        }
    }
}
