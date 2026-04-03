using System.ComponentModel.DataAnnotations;

namespace FraudNet.API.Models.Company;

public class CompanyForUpdateDTO
{
    [Required(ErrorMessage = "A name must be provided.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
}
