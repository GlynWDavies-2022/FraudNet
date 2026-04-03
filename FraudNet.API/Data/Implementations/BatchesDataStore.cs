using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Batch;

namespace FraudNet.API.Data.Implementations;

public class BatchesDataStore : IBatchesDataStore
{
    public List<BatchSummaryDTO> Batches { get; }

    public BatchesDataStore()
    {
        Batches =
        [
            new()
            {
                Id = 1,
                FileName = "ABD-20260403-01.txt",
                Timestamp = DateTime.Now,
            },
            new()
            {
                Id = 2,
                FileName = "ABD-20260403-02.txt",
                Timestamp = DateTime.Now,
            },
            new()
            {
                Id = 3,
                FileName = "ABD-20260403-03.txt",
                Timestamp = DateTime.Now,
            }
        ];
    }

    public int GetNextId()
    {
        return Batches.Max(b => b.Id) + 1;
    }

    public BatchSummaryDTO CreateBatch(BatchForCreationDTO batch)
    {
        var newId = GetNextId();

        var batchSummaryDTO = new BatchSummaryDTO
        {
            Id = newId,
            FileName = batch.FileName
        };

        Batches.Add(batchSummaryDTO);

        return batchSummaryDTO;
    }

    public void DeleteBatch(int id)
    {
        var batchToRemove = Batches.Find(b => b.Id == id);

        if (batchToRemove == null)
        {
            return;
        }

        Batches.Remove(batchToRemove);
    }
}
