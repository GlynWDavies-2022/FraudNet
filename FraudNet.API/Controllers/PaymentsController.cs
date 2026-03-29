using FraudNet.API.Data.Contracts;
using FraudNet.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FraudNet.API.Controllers;

[ApiController]
[Route("/api/payments")]
public class PaymentsController : ControllerBase
{
    private IPaymentsDataStore _paymentsDataStore;

    public PaymentsController(IPaymentsDataStore paymentsDataStore)
    {
        _paymentsDataStore = paymentsDataStore;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<PaymentDTO>> GetPayments()
    {
        return new JsonResult(_paymentsDataStore.Payments);
    }

    [HttpGet("{id}")]
    public ActionResult<PaymentDTO> GetCityById(int id)
    {
        var payment = _paymentsDataStore.Payments.FirstOrDefault(p => p.Id == id);

        if (payment is null)
        {
            return NotFound();
        }

        return Ok(payment);
    }
}
