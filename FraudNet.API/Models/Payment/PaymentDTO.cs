using FraudNet.API.Entities;
using FraudNet.API.Enums;
using FraudNet.API.Models.Payee;

namespace FraudNet.API.Models.Payment;

public class PaymentDTO
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public string? Reference { get; set; }
    public PayeeDTO Payee { get; set; } = new();
    public PaymentType PaymentType { get; set; } = PaymentType.RECURRING;
}
