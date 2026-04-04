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

    private readonly ILogger<BatchesController> _logger;

    public BatchesController(IBatchesDataStore batchesDataStore, ILogger<BatchesController> logger)
    {
        _batchesDataStore = batchesDataStore;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<BatchDTO> CreateBatch([FromBody] BatchForCreationDTO batch)
    {
        var createdBatch = _batchesDataStore.CreateBatch(batch);

        return CreatedAtAction(
                nameof(GetBatchById),
                new
                {
                    batchId = createdBatch.Id,
                },
                createdBatch
            );
    }

    [HttpGet]
    public ActionResult<IEnumerable<BatchDTO>> GetBatches()
    {
        var batches = _batchesDataStore.Batches;

        if (batches is null)
        {
            _logger.LogInformation("No batches were found.");

            return NotFound();
        }

        return Ok(batches);
    }

    [HttpGet("{batchId}", Name = "GetBatch")]
    public ActionResult<IEnumerable<BatchDTO>> GetBatchById(int batchId)
    {
        var batch = _batchesDataStore.Batches.FirstOrDefault(b => b.Id == batchId);

        if (batch is null)
        {
            _logger.LogInformation("No batch was found with an id of {id}", batchId);

            return NotFound();
        }

        return Ok(batch);
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
        };

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
