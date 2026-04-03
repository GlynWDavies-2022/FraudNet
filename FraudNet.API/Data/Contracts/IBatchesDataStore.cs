using FraudNet.API.Models.Batch;

namespace FraudNet.API.Data.Contracts;

public interface IBatchesDataStore
{
    public List<BatchSummaryDTO> Batches { get; }
    public int GetNextId();
    public BatchSummaryDTO CreateBatch(BatchForCreationDTO batch);
    public void DeleteBatch(int id);
}
