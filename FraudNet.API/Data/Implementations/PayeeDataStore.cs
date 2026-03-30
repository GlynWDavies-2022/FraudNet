using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payee;

namespace FraudNet.API.Data.Implementations;

public class PayeeDataStore : IPayeeDataStore
{
    public List<PayeeDTO> Payees { get; }

    public PayeeDataStore()
    {
        Payees = 
        [
            new() 
            {
                Id = 1,
                Name = "Anne Alpha"
            },
            new()
            {
                Id = 2,
                Name = "Brian Bravo"
            },
            new()
            {
                Id = 3,
                Name = "Carol Charlie"
            },
            new()
            {
                Id = 4,
                Name = "Darryl Delta"
            },
            new()
            {
                Id = 5,
                Name = "Elaine Echo"
            },
        ];
    }

    public int GetNextId()
    {
        return Payees.Max(p  => p.Id) + 1;
    }

    public PayeeDTO CreatePayee(PayeeForCreationDTO newPayee)
    {
        var newId = GetNextId();

        var payeeDTO = new PayeeDTO
        {
            Id = newId,
            Name = newPayee.Name,
        };

        Payees.Add(payeeDTO);

        return payeeDTO;
    }
}
