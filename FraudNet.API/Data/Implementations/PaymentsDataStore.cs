using FraudNet.API.Data.Contracts;
using FraudNet.API.Enums;
using FraudNet.API.Models.Payee;
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
                Payee = new PayeeDTO
                {
                    Id = 1,
                    Name = "Anne Alpha",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    
                },
                PaymentType = PaymentType.RECURRING
            },
            new()
            {
                Payee = new PayeeDTO
                {
                    Id = 2,
                    Name = "Brendan Bravo",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,

                },
                PaymentType = PaymentType.RECURRING
            },
        ];
    }

    public PaymentDTO CreatePayment(PaymentForCreationDTO payment)
    {
        var newId = GetNewId();

        var paymentDTO = new PaymentDTO
        {
            Id = newId,
            Timestamp = DateTime.Now,
            Amount = payment.Amount,
            Reference = payment.Reference,
            Payee = payment.Payee,
            PaymentType = payment.PaymentType
        };

        Payments.Add(paymentDTO);

        return paymentDTO;
    }

    public int GetNewId()
    {
        return Payments.Max(p => p.Id) + 1;
    }
}
