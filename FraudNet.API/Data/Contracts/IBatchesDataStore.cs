using FraudNet.API.Models.Batch;

namespace FraudNet.API.Data.Contracts;

public interface IBatchesDataStore
{
    public List<BatchDTO> Batches { get; }
}
