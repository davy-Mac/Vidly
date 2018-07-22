using AutoMapper;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // constructor of the mapping profile
        {
            Mapper.CreateMap<Customer, CustomerDto>(); // creates a mapping configuration between 2 types (generic method that takes 2 parameters "source" and "target")
            Mapper.CreateMap<CustomerDto, Customer>(); // maps CustomerDto to Customer
        }
    }
}
