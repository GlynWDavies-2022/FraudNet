using FraudNet.API.Models.Batch;

namespace FraudNet.API.Models.Company;

public class CompanyDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<BatchSummaryDTO> Batches { get; set; } = [];
}
