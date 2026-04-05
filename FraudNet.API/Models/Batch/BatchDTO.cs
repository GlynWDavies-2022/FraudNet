using FraudNet.API.Controllers;
using FraudNet.API.Models.Payment;

namespace FraudNet.API.Models.Batch;

public class BatchDTO
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public int PaymentCount => Payments.Count;
    public ICollection<PaymentDTO> Payments { get; set; } = [];
}
