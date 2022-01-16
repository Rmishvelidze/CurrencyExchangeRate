using System.Collections.Generic;

namespace ExchangeRate.Application.Features.Banks.Queries.GetAll
{
    public class GetAllBanksResponce
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public ICollection<string> Currencies { get; set; }
    }
}
