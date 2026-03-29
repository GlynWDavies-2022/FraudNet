using FraudNet.API.Models;

namespace FraudNet.API.Data.Contracts;

public interface IBatchesDataStore
{
    public List<BatchDTO> Batches { get; }
}
