using FraudNet.API.Enums;
using FraudNet.API.Models.Payee;
using System.ComponentModel.DataAnnotations;

namespace FraudNet.API.Models.Payment;

public class PaymentForCreationDTO
{
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string? Reference { get; set; }
    [Required]
    public PayeeDTO Payee { get; set; } = new();
    [Required]
    public PaymentType PaymentType { get; set; } = PaymentType.RECURRING;
}
