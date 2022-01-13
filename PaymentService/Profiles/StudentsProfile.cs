using AutoMapper;

namespace PaymentService.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Models.Student, Dtos.PaymentDto>();
        }
    }
}
