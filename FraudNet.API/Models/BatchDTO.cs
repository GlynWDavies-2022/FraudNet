namespace FraudNet.API.Models;

public class BatchDTO
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public CompanyDTO Company { get; set; } = new();
    public ICollection<PaymentDTO> Payments { get; set; } = [];
    public int PaymentCount
    {
        get => Payments.Count;
    }
}
