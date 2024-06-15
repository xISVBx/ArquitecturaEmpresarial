using AutoMapper;
using Ecommerce.Domain.Entity;
using Ecommerce.Application.DTO;

namespace Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
        }
    }
}
