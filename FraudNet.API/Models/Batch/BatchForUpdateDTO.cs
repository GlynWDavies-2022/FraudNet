using System.ComponentModel.DataAnnotations;

namespace FraudNet.API.Models.Batch;

public class BatchForUpdateDTO
{
    [Required(ErrorMessage = "A file name must be provided.")]
    [MaxLength(50)]
    public string FileName { get; set; } = string.Empty;
}
