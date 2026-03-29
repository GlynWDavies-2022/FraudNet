using FraudNet.API.Data.Contracts;
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

    [HttpGet]
    public ActionResult<IEnumerable<CompanyDTO>> GetCompanies()
    {
        return Ok(_companiesDataStore.Companies.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<CompanyDTO> GetCompanyById(int id)
    {
        var company = _companiesDataStore.Companies.FirstOrDefault(c => c.Id == id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }
}
