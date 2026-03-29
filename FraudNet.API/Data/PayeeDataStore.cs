using FraudNet.API.Models;

namespace FraudNet.API.Data;

public class PayeeDataStore : IPayeeDataStore
{
    public List<PayeeDTO> Payees => throw new NotImplementedException();
}
