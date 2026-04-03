using FraudNet.API.Data.Contracts;
using FraudNet.API.Data.Implementations;
using FraudNet.API.Models.Batch;
using FraudNet.API.Models.Company;
using FraudNet.API.Models.Payee;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompaniesDataStore _companiesDataStore;

    public CompaniesController(ICompaniesDataStore companiesDataStore)
    {
        _companiesDataStore = companiesDataStore;
    }

    [HttpPost]
    public ActionResult<CompanySummaryDTO> CreateCompany([FromBody] CompanyForCreationDTO company)
    {
        var createdCompany = _companiesDataStore.CreateCompany(company);

        return CreatedAtAction(
                nameof(GetCompanyById),
                new
                {
                    id = createdCompany.Id,
                },
                createdCompany
            );
    }

    [HttpGet]
    public ActionResult<IEnumerable<CompanySummaryDTO>> GetCompanies()
    {
        var companies = _companiesDataStore.Companies.ToList();

        return Ok(companies);
    }

    [HttpGet("{id}",Name = "GetCompany")]
    public ActionResult<CompanySummaryDTO> GetCompanyById(int id)
    {
        var company = _companiesDataStore.Companies.FirstOrDefault(c => c.Id == id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCompany(CompanyForUpdateDTO company, int id)
    {
        if (company == null)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }

        var companyToUpdate = _companiesDataStore.Companies.FirstOrDefault(c => c.Id == id);

        if (companyToUpdate == null)
        {
            return NotFound();
        }
        ;

        companyToUpdate.Name = company.Name;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdateCompany(int id, JsonPatchDocument<CompanyForUpdateDTO> company)
    {
        var companyFromStore = _companiesDataStore.Companies.FirstOrDefault(p => p.Id == id);

        if (companyFromStore == null)
        {
            return NotFound();
        }

        var companyToPatch = new CompanyForUpdateDTO()
        {
            Name = companyFromStore.Name!
        };

        company.ApplyTo(companyToPatch, jsonPatchError =>
        {
            var key = jsonPatchError.AffectedObject.GetType().Name;
            ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!TryValidateModel(companyToPatch))
        {
            return BadRequest(ModelState);
        }

        companyFromStore.Name = companyToPatch.Name;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCompany(int id)
    {
        _companiesDataStore.DeleteCompany(id);

        return NoContent();
    }
}
