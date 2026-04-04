using FraudNet.API.Data.Contracts;
using FraudNet.API.Data.Implementations;
using FraudNet.API.Models.Batch;
using FraudNet.API.Models.Payment;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[ApiController]
[Route("/api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentsDataStore _paymentsDataStore;

    public PaymentsController(IPaymentsDataStore paymentsDataStore)
    {
        _paymentsDataStore = paymentsDataStore;
    }

    [HttpPost]
    public ActionResult<PaymentDTO> CreatePayee([FromBody] PaymentForCreationDTO payment)
    {
        var createdPayment = _paymentsDataStore.CreatePayment(payment);

        return CreatedAtAction(
                nameof(GetPaymentById),
                new 
                {
                    id = createdPayment.Id,
                },
                createdPayment
            );
    }

    [HttpGet()]
    public ActionResult<IEnumerable<PaymentDTO>> GetPayments()
    {
        return _paymentsDataStore.Payments;
    }

    [HttpGet("{id}", Name = "GetPayment")]
    public ActionResult<PaymentDTO> GetPaymentById(int id)
    {
        var payment = _paymentsDataStore.Payments.FirstOrDefault(p => p.Id == id);

        if (payment is null)
        {
            return NotFound();
        }

        return Ok(payment);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePayment(PaymentForUpdateDTO payment, int id)
    {
        if (payment == null)
        {
            return BadRequest();
        }

        if (id == 0)
        {
            return BadRequest();
        }

        var paymentToUpdate = _paymentsDataStore.Payments.FirstOrDefault(p => p.Id == id);

        if (paymentToUpdate == null)
        {
            return NotFound();
        };

        paymentToUpdate.Amount = payment.Amount;
        paymentToUpdate.Reference = payment.Reference;
        paymentToUpdate.Payee = payment.Payee;
        paymentToUpdate.PaymentType = payment.PaymentType;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult UpdatePayment(int id, JsonPatchDocument<PaymentForUpdateDTO> payment)
    {
        var paymentFromStore = _paymentsDataStore.Payments.FirstOrDefault(p => p.Id == id);

        if (paymentFromStore == null)
        {
            return NotFound();
        }

        var paymentToPatch = new PaymentForUpdateDTO()
        {
            Amount = paymentFromStore.Amount,
            Reference = paymentFromStore.Reference,
            Payee = paymentFromStore.Payee,
            PaymentType = paymentFromStore.PaymentType
        };

        payment.ApplyTo(paymentToPatch, jsonPatchError =>
        {
            var key = jsonPatchError.AffectedObject.GetType().Name;

            ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!TryValidateModel(paymentToPatch))
        {
            return BadRequest(ModelState);
        }

        paymentFromStore.Amount = paymentToPatch.Amount;
        paymentFromStore.Reference = paymentToPatch.Reference;
        paymentFromStore.Payee = paymentToPatch.Payee;
        paymentFromStore.PaymentType = paymentToPatch.PaymentType;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public void DeletePayment(int id)
    {
        _paymentsDataStore.DeletePayment(id);
    }
}
