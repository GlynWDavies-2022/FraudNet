namespace FraudNet.API.Models;

public class CompanyDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BatchDTO> Batches { get; set; } = [];
}
