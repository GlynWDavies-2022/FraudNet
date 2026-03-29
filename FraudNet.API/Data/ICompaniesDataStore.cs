using FraudNet.API.Models;

namespace FraudNet.API.Data;

public interface ICompaniesDataStore
{
    public List<CompanyDTO> Companies { get; }
}
