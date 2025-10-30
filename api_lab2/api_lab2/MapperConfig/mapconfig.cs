
using api_lab2.Controllers;
using api_lab2.DTOs;
using api_lab2.Models;
using AutoMapper;
namespace api_lab2.MapperConfig
{
    public class mapconfig : Profile
    {


        public mapconfig()
        {
            CreateMap<Student, StudentDTO>()

            .ForMember(dest => dest.dept_name, opt => opt.MapFrom(src => src.department != null ? src.department.Dept_Name : null))
            .ForMember(dest => dest.supervisor_name, opt => opt.MapFrom(src => src.instructor != null ? src.instructor.Ins_Name : null))
            .ReverseMap();


            CreateMap<Department, DepartmentDTO>()
            .ForMember( dest => dest.num_students,opt => opt.MapFrom(src => src.students != null ? src.students.Count : 0))
            .ReverseMap();

        }
    }
}
