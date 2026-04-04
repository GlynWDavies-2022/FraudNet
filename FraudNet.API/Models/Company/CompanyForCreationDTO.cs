using FraudNet.API.Models.Batch;
using System.ComponentModel.DataAnnotations;

namespace FraudNet.API.Models.Company;

public class CompanyForCreationDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A name must be provided.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public ICollection<BatchDTO> Batches { get; set; } = [];
}
