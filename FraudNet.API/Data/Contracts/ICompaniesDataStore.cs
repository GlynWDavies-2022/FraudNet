using FraudNet.API.Models;

namespace FraudNet.API.Data.Contracts;

public interface ICompaniesDataStore
{
    public List<CompanyDTO> Companies { get; }
}
