namespace FraudNet.API.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateUpdated { get; set; } = DateTime.Now;
}
