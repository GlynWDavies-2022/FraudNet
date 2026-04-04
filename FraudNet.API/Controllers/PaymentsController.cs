using FraudNet.API.Data.Contracts;
using FraudNet.API.Models.Payment;
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
}
