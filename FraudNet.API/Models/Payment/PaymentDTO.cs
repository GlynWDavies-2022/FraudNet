using FraudNet.API.Entities;

namespace FraudNet.API.Models.Payment;

public class PaymentDTO
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
    public string? Reference { get; set; }
    public string? Payee { get; set; }
    public string? PaymentType { get; set; }
}
