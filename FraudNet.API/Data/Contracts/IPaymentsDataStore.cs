using FraudNet.API.Models.Payment;

namespace FraudNet.API.Data.Contracts
{
    public interface IPaymentsDataStore
    {
        public List<PaymentDTO> Payments { get; }
        public PaymentDTO CreatePayment(PaymentForCreationDTO payment);
        public void DeletePayment(int paymentId);
        public int GetNewId();
    }
}