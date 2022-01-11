using AutoMapper;

namespace RestAPIStudyCase.Profiles
{
    public class EnrollmentsProfile : Profile
    {
        public EnrollmentsProfile()
        {
            CreateMap<Models.Enrollment, Dtos.EnrollmentDto>();

            CreateMap<Dtos.EnrollmentForCreateDto, Models.Enrollment>();
            CreateMap<Dtos.EnrollmentDto, Models.Enrollment>();
        }
    }
}
