using FraudNet.API.Models;

namespace FraudNet.API.Data.Contracts
{
    public interface IPaymentsDataStore
    {
        public List<PaymentDTO> Payments { get; }
    }
}