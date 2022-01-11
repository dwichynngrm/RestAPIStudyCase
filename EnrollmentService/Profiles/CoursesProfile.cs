using AutoMapper;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, Dtos.CourseDto>()
                .ForMember(dest => dest.TotalHours,
                opt => opt.MapFrom(src => src.Credits * 1.5));

            CreateMap<Dtos.CourseForCreateDto, Course>();
        }
    }
}
