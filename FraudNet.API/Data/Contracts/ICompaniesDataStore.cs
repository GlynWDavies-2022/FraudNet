using FraudNet.API.Models.Company;

namespace FraudNet.API.Data.Contracts;

public interface ICompaniesDataStore
{
    public List<CompanySummaryDTO> Companies { get; }
    public int GetNextId();
    public CompanySummaryDTO CreateCompany(CompanyForCreationDTO company);
    public void DeleteCompany(int id);
}
