using System.Collections.Generic;

namespace ExchangeRate.Application.DTOs.Banks
{
    public class BanksDTO
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public IEnumerable<string> Currencies { get; set; }
    }
}
