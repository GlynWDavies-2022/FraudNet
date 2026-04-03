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
                Batches = []
            }
        ];
    }
}
