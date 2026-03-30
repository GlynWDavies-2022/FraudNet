using FraudNet.API.Models.Payee;

namespace FraudNet.API.Data.Contracts;

public interface IPayeeDataStore
{
    public List<PayeeDTO> Payees { get; }
    public int GetNextId();
    public void CreatePayee(PayeeForCreationDTO payee);
}
