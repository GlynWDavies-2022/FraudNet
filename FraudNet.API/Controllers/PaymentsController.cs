using FraudNet.API.Data;
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
    public JsonResult GetPayments()
    {
        return new JsonResult(_paymentsDataStore.Payments);
    }

    [HttpGet("{id}")]
    public JsonResult GetCityById(int id)
    {
        return new JsonResult(_paymentsDataStore.Payments.FirstOrDefault(p => p.Id == id));
    }
}
