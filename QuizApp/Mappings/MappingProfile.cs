using AutoMapper;
using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDto, ApplicationUser>();
        }
    }
}
