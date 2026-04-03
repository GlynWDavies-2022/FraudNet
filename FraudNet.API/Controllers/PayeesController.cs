using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payee;
using FraudNet.API.Services;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[Route("api/payees")]
[ApiController]
public class PayeesController(IPayeeDataStore payeeDataStore,
                              ILogger<PayeesController> logger) : ControllerBase
{
    [HttpPost]
    public ActionResult<PayeeDTO> CreatePayee([FromBody] PayeeForCreationDTO payee)
    {
        var createdPayee = payeeDataStore.CreatePayee(payee);

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
        var payees = payeeDataStore.Payees;

        if (payees is null)
        {
            logger.LogInformation("No payees were found.");

            return NotFound();
        }

        return Ok(payees);
    }

    [HttpGet("{id}", Name = "GetPayee")]
    public ActionResult<PayeeDTO> GetPayeeById(int id)
    {
        var payee = payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payee == null)
        {
            logger.LogInformation("No payee was found with an id of {id}", id);

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

        var payeeToUpdate = payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

        if (payeeToUpdate == null)
        {
            return NotFound();
        }
        ;

        payeeToUpdate.Name = payee.Name;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdatePayee(int id, JsonPatchDocument<PayeeForUpdateDTO> payee)
    {
        var payeeFromStore = payeeDataStore.Payees.FirstOrDefault(p => p.Id == id);

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
        payeeDataStore.DeletePayee(id);

        return NoContent();
    }
}
