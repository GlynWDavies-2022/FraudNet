using FraudNet.API.Data;
using FraudNet.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[Route("api/companies/{companyId}/batches")]
[ApiController]
public class BatchesController : ControllerBase
{
    private readonly ICompaniesDataStore _companiesDataStore;

    public BatchesController(ICompaniesDataStore companiesDataStore)
    {
        _companiesDataStore = companiesDataStore;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BatchDTO>> GetBatches(int companyId)
    {
        var company = _companiesDataStore.Companies.FirstOrDefault(c => c.Id == companyId);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company.Batches);
    }

    [HttpGet("{batchId}")]
    public ActionResult<IEnumerable<BatchDTO>> GetBatchById(int companyId, int batchId)
    {
        var company = _companiesDataStore.Companies.FirstOrDefault(c => c.Id == companyId);

        if (company is null)
        {
            return NotFound();
        }

        var batch = company.Batches.FirstOrDefault(b => b.Id == batchId);

        if (batch is null)
        {
            return NotFound();
        }

        return Ok(batch);
    }
}
