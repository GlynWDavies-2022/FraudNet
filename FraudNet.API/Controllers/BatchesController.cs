using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Batch;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[Route("api/batches")]
[ApiController]
public class BatchesController : ControllerBase
{
    private readonly IBatchesDataStore _batchesDataStore;

    public BatchesController(IBatchesDataStore batchesDataStore)
    {
        _batchesDataStore = batchesDataStore;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BatchDetailDTO>> GetBatches(int companyId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{batchId}")]
    public ActionResult<IEnumerable<BatchDetailDTO>> GetBatchById(int batchId)
    {
        throw new NotImplementedException();
    }
}
