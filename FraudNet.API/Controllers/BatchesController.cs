using FraudNet.API.Data.Contracts;
using FraudNet.API.Data.Implementations;
using FraudNet.API.Models.Batch;
using FraudNet.API.Models.Payee;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
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

    [HttpPost]
    public ActionResult<BatchSummaryDTO> CreateBatch([FromBody] BatchForCreationDTO batch)
    {
        var createdBatch = _batchesDataStore.CreateBatch(batch);

        return CreatedAtAction(
                nameof(GetBatchById),
                new
                {
                    id = createdBatch.Id,
                },
                createdBatch
            );
    }

    [HttpGet]
    public ActionResult<IEnumerable<BatchDetailDTO>> GetBatches(int companyId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{batchId}", Name = "GetBatch")]
    public ActionResult<IEnumerable<BatchDetailDTO>> GetBatchById(int batchId)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBatch(BatchForUpdateDTO batch, int id)
    {
        if (batch == null)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }

        var batchToUpdate = _batchesDataStore.Batches.FirstOrDefault(b => b.Id == id);

        if (batchToUpdate == null)
        {
            return NotFound();
        }
        ;

        batchToUpdate.FileName = batch.FileName;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdateBatch(int id, JsonPatchDocument<BatchForUpdateDTO> batch)
    {
        var batchFromStore = _batchesDataStore.Batches.FirstOrDefault(b => b.Id == id);

        if (batchFromStore == null)
        {
            return NotFound();
        }

        var batchToPatch = new BatchForUpdateDTO()
        {
            FileName = batchFromStore.FileName
        };

        batch.ApplyTo(batchToPatch, jsonPatchError =>
        {
            var key = jsonPatchError.AffectedObject.GetType().Name;
            
            ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!TryValidateModel(batchToPatch))
        {
            return BadRequest(ModelState);
        }

        batchFromStore.FileName = batchToPatch.FileName;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePointOfInterest(int id)
    {
        _batchesDataStore.DeleteBatch(id);

        return NoContent();
    }

}
