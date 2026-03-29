using FraudNet.API.Models.Payment;

namespace FraudNet.API.Models.Batch;

public class BatchDTO
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public ICollection<PaymentDTO> Payments { get; set; } = [];
    public int PaymentCount
    {
        get => Payments.Count;
    }
}
