using FraudNet.API.Models.Payee;

namespace FraudNet.API.Data.Contracts;

public interface IPayeeDataStore
{
    public List<PayeeDTO> Payees { get; }
    public int GetNextId();
    public PayeeDTO CreatePayee(PayeeForCreationDTO payee);
    public void DeletePayee(int id);
}
