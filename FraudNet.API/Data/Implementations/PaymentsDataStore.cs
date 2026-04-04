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
                Amount = 1000M,
                Reference = "ABD-20260404-01",
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
                Id = 2,
                Timestamp = DateTime.Now,
                Amount = 1500M,
                Reference = "ABD-20260404-02",
                Payee = new PayeeDTO
                {
                    Id = 2,
                    Name = "Brian Bravo",
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

    public void DeletePayment(int id)
    {
        var paymentToDelete = Payments.Find(p => p.Id == id);

        if (paymentToDelete == null)
        {
            return;
        }

        Payments.Remove(paymentToDelete);
    }

    public int GetNewId()
    {
        return Payments.Max(p => p.Id) + 1;
    }
}
