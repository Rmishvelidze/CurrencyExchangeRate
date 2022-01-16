using AutoMapper;
using ExchangeRate.Domain.Entities.Catalog;

namespace ExchangeRate.Application.Mappings
{
    internal class BankByCurrencyProfile : Profile
    {
        public BankByCurrencyProfile()
        {
            CreateMap<BankByCurrencyProfile,ExchangeRateData>().ReverseMap();
        }
    }
}
