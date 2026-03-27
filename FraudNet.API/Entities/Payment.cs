namespace FraudNet.API.Entities;

public class Payment : BaseEntity, IEquatable<Payment>
{
    public required DateTime Timestamp { get; set; }
    public required decimal Amount { get; set; }
    public required string Reference {  get; set; }
    public required int PayeeId { get; set; }
    public Payee? Payee { get; set; }
    public required PaymentType Type { get; set; }
    public required int BatchId { get; set; }
    public Batch? Batch { get; set; }

    public bool Equals(Payment? other)
    {
        if (other is null)
        {
            return false;
        }

        return
            Amount.Equals(other.Amount)
            &&
            Reference.Equals(other.Reference);
    }

    public override bool Equals(object? obj) => Equals(obj as Payment);

    public override int GetHashCode() => HashCode.Combine(
        Timestamp,
        Amount,
        Reference,
        PayeeId, 
        Type,
        BatchId 
    );
    
}
