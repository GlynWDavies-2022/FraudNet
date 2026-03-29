using FraudNet.API.Models;

namespace FraudNet.API.Data.Contracts;

public interface IPayeeDataStore
{
    public List<PayeeDTO> Payees { get; }
}
