using FraudNet.API.Models;

namespace FraudNet.API.Data;

public interface IBatchesDataStore
{
    public List<BatchDTO> Batches { get; }
}
