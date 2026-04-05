using FraudNet.API.Models.Company;

namespace FraudNet.API.Data.Contracts;

public interface ICompaniesDataStore
{
    public List<CompanyDTO> Companies { get; }
    public int GetNextId();
    public CompanyDTO CreateCompany(CompanyForCreationDTO company);
    public bool UpdateCompany(int id, CompanyForUpdateDTO company);
    public void DeleteCompany(int id);
}
