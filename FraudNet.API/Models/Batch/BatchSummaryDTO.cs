using FraudNet.API.Models.Payment;

namespace FraudNet.API.Models.Batch;

public class BatchSummaryDTO
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
