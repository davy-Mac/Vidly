using AutoMapper;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // constructor of the mapping profile
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>(); // creates a mapping configuration between 2 types (generic method that takes 2 parameters "source" and "target")

            Mapper.CreateMap<Movie, MovieDto>(); // creates a mapping configuration between 'Movie' and 'MovieDto'


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); // Id id te key property for the Movie class, and a key property should not be changed

            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore()); // the opt.Ignore tells AutoMapper to ignore Id during mapping of a MovieDto to Movie 
        }
    }
}
