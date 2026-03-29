using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payee;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[Route("api/payees")]
[ApiController]
public class PayeesController : ControllerBase
{
    private readonly IPayeeDataStore _payeeDataStore;

    public PayeesController(IPayeeDataStore payeeDataStore)
    {
        _payeeDataStore = payeeDataStore;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PayeeDTO>> GetPayees()
    {
        var payees = _payeeDataStore.Payees.ToList();

        if (payees is null)
        {
            return NotFound();
        }

        return Ok(payees);
    }

    [HttpGet("{id}")]
    public ActionResult<PayeeDTO> GetPayeeById(int id)
    {
        var payee = _payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payee == null)
        {
            return NotFound();
        }

        return Ok(payee);
    }
}
