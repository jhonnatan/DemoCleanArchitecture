using AutoMapper;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.Customer.Customer, Domain.Customer.Customer>().ReverseMap();
        }
    }
}
