namespace FraudNet.API.Entities;

public class Payment : BaseEntity
{
    public required DateTime PaymentDate { get; set; }
    public required decimal Amount { get; set; }
    public required string Reference {  get; set; }
    public required int PayeeId { get; set; }
    public required Payee Payee { get; set; }
    public required PaymentType Type { get; set; }
}
