using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Batch;
using FraudNet.API.Models.Company;
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
}
