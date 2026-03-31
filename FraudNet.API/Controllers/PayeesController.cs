using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payee;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
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

    [HttpPost]
    public ActionResult<PayeeDTO> CreatePayee([FromBody] PayeeForCreationDTO payee)
    {
        var createdPayee = _payeeDataStore.CreatePayee(payee);

        return CreatedAtAction(
            nameof(GetPayeeById),
            new
            {
               id = createdPayee.Id,
            },
            createdPayee
        );
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

    [HttpGet("{id}", Name = "GetPayee")]
    public ActionResult<PayeeDTO> GetPayeeById(int id)
    {
        var payee = _payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payee == null)
        {
            return NotFound();
        }

        return Ok(payee);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePayee(PayeeForUpdateDTO payee, int id)
    {
        if (payee == null)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }

        var payeeToUpdate = _payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payeeToUpdate == null)
        {
            return NotFound();
        };

        payeeToUpdate.Name = payee.Name;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdatePayee(int id, JsonPatchDocument<PayeeForUpdateDTO> payee)
    {
        var payeeFromStore = _payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payeeFromStore == null)
        {
            return NotFound();
        }

        var payeeToPatch = new PayeeForUpdateDTO()
        {
            Name = payeeFromStore.Name
        };

        payee.ApplyTo(payeeToPatch, jsonPatchError =>
        {
            var key = jsonPatchError.AffectedObject.GetType().Name;
            ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!TryValidateModel(payeeToPatch))
        {
            return BadRequest(ModelState);
        }

        payeeFromStore.Name = payeeToPatch.Name;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePointOfInterest(int id)
    {
        _payeeDataStore.DeletePayee(id);

        return NoContent();
    }
}
