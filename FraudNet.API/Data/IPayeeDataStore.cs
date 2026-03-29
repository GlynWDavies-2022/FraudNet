using FraudNet.API.Models;

namespace FraudNet.API.Data;

public interface IPayeeDataStore
{
    public List<PayeeDTO> Payees { get; }
}
