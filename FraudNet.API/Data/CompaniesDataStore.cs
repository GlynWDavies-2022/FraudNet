using FraudNet.API.Models;

namespace FraudNet.API.Data;

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
                Name = "Abode"
            },
            new()
            {
                Id = 2,
                Name = "Crib"
            },
            new()
            {
                Id = 3,
                Name = "Digs"
            },
            new()
            {
                Id = 4,
                Name = "Dwelling"
            },
            new()
            {
                Id = 5,
                Name = "Habitat"
            }
        ];
    }
}
