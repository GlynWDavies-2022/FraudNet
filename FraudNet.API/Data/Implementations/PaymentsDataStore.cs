using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payment;

namespace FraudNet.API.Data.Implementations;

public class PaymentsDataStore : IPaymentsDataStore
{
    public List<PaymentDTO> Payments { get; private set; }

    public PaymentsDataStore()
    {
        Payments =
        [
            new()
            {
                Id = 1,
                Timestamp = DateTime.Now,
                Amount = 999M,
                Reference = "A-123",
                Payee = "Anne Alpha",
                PaymentType = "Recurring"
            },
            new()
            {
                Id = 2,
                Timestamp = DateTime.Now,
                Amount = 999M,
                Reference = "A-456",
                Payee = "Brian Bravo",
                PaymentType = "Recurring"
            },
        ];
    }
}
