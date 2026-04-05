using FraudNet.API.Data.Contracts;
using FraudNet.API.Entities;
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
                        FileName = "ABD-20260404-01.txt",
                        Timestamp = DateTime.Now,
                        Payments = 
                        [
                            new() 
                            {
                                Id = 1,
                                Timestamp = DateTime.Now,
                                Reference = "ABD-20260404-01",
                                Amount = 1000M,
                                Payee = new() {
                                    Id = 1,
                                    Name = "Greta Golf",
                                    DateCreated = DateTime.Now,
                                    DateUpdated = DateTime.Now,
                                },
                                PaymentType = Enums.PaymentType.RECURRING,
                            }
                        ],
                    }
                ],
            }
        ];
    }

    public int GetNextId()
    {
        return Companies.Max(p => p.Id) + 1;
    }

    public CompanyDTO CreateCompany(CompanyForCreationDTO company)
    {
        var newId = GetNextId();

        var companyDTO = new CompanyDTO
        {
            Id = newId,
            Name = company.Name,
            Batches = company.Batches,
        };

        Companies.Add(companyDTO);

        return companyDTO;
    }

    public bool UpdateCompany(int id, CompanyForUpdateDTO company)
    {
        var companyToUpdate = Companies.Find(c  => c.Id == id);

        if (companyToUpdate != null)
        {
            companyToUpdate.Name = company.Name;

            return true;
        }

        return false;
    }

    public void DeleteCompany(int id)
    {
        var companyToRemove = Companies.Find(c => c.Id == id);

        if (companyToRemove is null)
        {
            return;
        }

        Companies.Remove(companyToRemove);
    }
}
