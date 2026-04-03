using FraudNet.API.Data.Contracts;
using FraudNet.API.Entities;
using FraudNet.API.Models.Company;

namespace FraudNet.API.Data.Implementations;

public class CompaniesDataStore : ICompaniesDataStore
{
    public List<CompanySummaryDTO> Companies { get; }

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

    public int GetNextId()
    {
        return Companies.Max(p => p.Id) + 1;
    }

    public CompanySummaryDTO CreateCompany(CompanyForCreationDTO company)
    {
        var newId = GetNextId();

        var companySummaryDTO = new CompanySummaryDTO
        {
            Id = newId,
            Name = company.Name,
        };

        Companies.Add(companySummaryDTO);

        return companySummaryDTO;
    }

    public void DeleteCompany(int id)
    {
        throw new NotImplementedException();
    }
}
