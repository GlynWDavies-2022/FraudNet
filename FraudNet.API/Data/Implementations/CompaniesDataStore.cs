using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Company;

namespace FraudNet.API.Data.Implementations;

public class CompaniesDataStore : ICompaniesDataStore
{
    public List<CompanyDTO> Companies { get; }

    public CompaniesDataStore()
    {
        Companies =
        [
            new()
            {
                Id = 1,
                Name = "Abode",
                Batches =
                [
                    new()
                    {
                        Id = 1,
                        FileName = "ABD-20260329-01.txt",
                        Payments =
                        [
                            new()
                            {
                                Id = 1,
                                Timestamp = DateTime.Now,
                                Amount = 999M,
                                Reference = "A-123",
                                Payee = "Anne Alpha",
                                PaymentType = "Recurring"
                            }
                        ]
                    }
                ]
            }
        ];
    }
}
