using FraudNet.API.Models.Batch;

namespace FraudNet.API.Data.Contracts;

public interface IBatchesDataStore
{
    public List<BatchDTO> Batches { get; }
    public int GetNextId();
    public BatchDTO CreateBatch(BatchForCreationDTO batch);
    public void DeleteBatch(int id);
    public int GetPaymentCount();
}
