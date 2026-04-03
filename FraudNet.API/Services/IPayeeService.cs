using FraudNet.API.Entities;

namespace FraudNet.API.Services;

public interface IPayeeService
{
    public Task<IEnumerable<Payee>> GetAllPayeesAsync();
}
