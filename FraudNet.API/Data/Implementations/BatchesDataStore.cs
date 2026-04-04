using FraudNet.API.Data.Contracts;
using FraudNet.API.Enums;
using FraudNet.API.Models.Batch;

namespace FraudNet.API.Data.Implementations;

public class BatchesDataStore : IBatchesDataStore
{
    public List<BatchDTO> Batches { get; }

    public BatchesDataStore()
    {
        Batches =
        [
            new()
            {
                Id = 1,
                FileName = "ABD-20260404-01.txt",
                Timestamp = DateTime.Now,
                Payments = 
                [
                    new() 
                    {
                        Id = 1,
                        Timestamp = DateTime.Now,
                        Amount = 1000M,
                        Reference = "ABD-20260404-01",
                        Payee = new()
                        {
                            Id = 1,
                            Name = "Anne Alpha",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                        },
                        PaymentType = PaymentType.RECURRING

                    }
                ]
            },
            new()
            {
                Id = 2,
                FileName = "ABD-20260404-02.txt",
                Timestamp = DateTime.Now,
                Payments =
                [
                    new()
                    {
                        Id = 2,
                        Timestamp = DateTime.Now,
                        Amount = 1200M,
                        Reference = "ABD-20260404-02",
                        Payee = new()
                        {
                            Id = 2,
                            Name = "Bernadette Bravo",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                        },
                        PaymentType = PaymentType.RECURRING

                    }
                ]
            },
            new()
            {
                Id = 3,
                FileName = "ABD-20260404-03.txt",
                Timestamp = DateTime.Now,
                Payments =
                [
                    new()
                    {
                        Id = 3,
                        Timestamp = DateTime.Now,
                        Amount = 1400M,
                        Reference = "ABD-20260404-03",
                        Payee = new()
                        {
                            Id = 3,
                            Name = "Crystal Charlie",
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                        },
                        PaymentType = PaymentType.RECURRING
                    }
                ]
            }
        ];
    }

    public BatchDTO CreateBatch(BatchForCreationDTO batch)
    {
        var newId = GetNextId();

        var batchDTO = new BatchDTO
        {
            Id = newId,
            FileName = batch.FileName,
            Timestamp = DateTime.Now,
            Payments = batch.Payments
        };

        Batches.Add(batchDTO);

        return batchDTO;
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

    public int GetNextId()
    {
        return Batches.Max(b => b.Id) + 1;
    }

    public int GetPaymentCount()
    {
        return Batches.ToList().Count;
    }
}
