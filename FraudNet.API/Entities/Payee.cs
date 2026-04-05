namespace FraudNet.API.Entities;

public class Payee : BaseEntity, IEquatable<Payee>
{
    public required string Name { get; set; }
    public required string SortCode { get; set; }
    public required string AccountNumber { get; set; }
    public string? RollNumber { get; set; }
    public int PaymentId { get; set; }
    public Payment? Payment { get; set; }

    public bool Equals(Payee? other)
    {
        if (other is null)
        {
            return false;
        }

        return 
            Name.Equals(other.Name)
            &&
            SortCode.Equals(other.SortCode)
            &&
            AccountNumber.Equals(other.AccountNumber);
    }

    public override bool Equals(object? obj) => Equals(obj as Payee);

    public override int GetHashCode() => HashCode.Combine(
        Name,
        SortCode,
        AccountNumber
    );

}
