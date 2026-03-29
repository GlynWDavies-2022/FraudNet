using FraudNet.API.Models.Company;

namespace FraudNet.API.Data.Contracts;

public interface ICompaniesDataStore
{
    public List<CompanyDTO> Companies { get; }
}
