using System.Security.Cryptography.Xml;

namespace FraudNet.API.Entities;

public class Company : BaseEntity, IEquatable<Company>
{
    public required string Name { get; set; }
    public ICollection<Batch> Batches { get; set; } = [];

    public bool Equals(Company? other)
    {
        if (other is null)
        {
            return false;
        }

        return
            Name.Equals(other.Name);
    }

    public override bool Equals(object? obj) => Equals(obj as Company);

    public override int GetHashCode() => HashCode.Combine(
        Name
    );
}
