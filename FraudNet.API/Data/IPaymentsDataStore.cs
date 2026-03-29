using FraudNet.API.Models;

namespace FraudNet.API.Data
{
    public interface IPaymentsDataStore
    {
        public List<PaymentDTO> Payments { get; }
    }
}