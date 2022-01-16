using AutoMapper;
using ExchangeRate.Application.Features.Banks.Queries.GetAll;
using ExchangeRate.Domain.Entities.Catalog;

namespace ExchangeRate.Application.Mappings
{
    internal class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<GetAllBanksQuery, Bank>().ReverseMap();
        }
    }
}
