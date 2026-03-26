namespace FraudNet.API.Entities;

public class Batch : BaseEntity
{
    public required string FileName { get; set; }
    public required DateTime Timestamp { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
}
