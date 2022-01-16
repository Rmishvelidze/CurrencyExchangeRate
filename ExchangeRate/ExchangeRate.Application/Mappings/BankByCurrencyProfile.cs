using AutoMapper;
using ExchangeRate.Application.Features.BanksByCurrency.Queries.GetExcangeRate;
using ExchangeRate.Domain.Entities.Catalog;

namespace ExchangeRate.Application.Mappings
{
    internal class BankByCurrencyProfile : Profile
    {
        public BankByCurrencyProfile()
        {
            CreateMap<GetBankByCurrencyQuery, ExchangeRateData>().ReverseMap();
        }
    }
}
