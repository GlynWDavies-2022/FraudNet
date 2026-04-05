using System.Security.Cryptography.Xml;

namespace FraudNet.API.Entities;

public class Batch : BaseEntity, IEquatable<Batch>
{
    public required string FileName { get; set; }
    public required DateTime Timestamp { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public ICollection<Payment> Payments { get; set; } = [];
    public int PaymentCount
    {
        get => Payments.Count;
    }

    public bool Equals(Batch? other)
    {
        if (other is null)
        {
            return false;
        }

        return
            FileName.Equals(other.FileName)
            &&
            Timestamp.Equals(other.Timestamp);
    }

    public override bool Equals(object? obj) => Equals(obj as Batch);

    public override int GetHashCode() => HashCode.Combine(
        FileName,
        Timestamp
    );
}
