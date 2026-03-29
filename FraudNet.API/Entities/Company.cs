namespace FraudNet.API.Entities;

public class Company : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<Batch> Batches { get; set; } = [];
}
