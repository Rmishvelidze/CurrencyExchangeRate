namespace ExchangeRate.Application.Features.Banks.Queries.GetById
{
    public class GetBankByIdResponce
    {
        public int Id { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
    }
}
