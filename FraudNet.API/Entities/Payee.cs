namespace FraudNet.API.Entities;

public class Payee : BaseEntity
{
    public required string Name { get; set; }
    public required string SortCode { get; set; }
    public required string AccountNumber { get; set; }
    public string? RollNumber { get; set; }
    public int PaymentId { get; set; }
    public Payment? Payment { get; set; }
}
