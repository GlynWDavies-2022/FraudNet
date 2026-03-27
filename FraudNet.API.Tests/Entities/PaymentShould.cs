using FraudNet.API.Entities;

namespace FraudNet.API.Tests.Entities;

public class PaymentShould
{
    [Fact]
    public void ReturnTrueWhenTwoPaymentsAreEqual()
    {
        // Arrange

        var payment = new Payment
        {
            Id = 1,
            Timestamp = new DateTime(2026,3,27,1,0,0),
            Amount = 999.99M,
            Reference = "ABC-12345",
            PayeeId = 1,
            Type = PaymentType.REGULAR,
            BatchId = 1,
        };

        var duplicate = new Payment
        {
            Id = 2,
            Timestamp = new DateTime(2026, 3, 27, 3, 0, 0),
            Amount = 999.99M,
            Reference = "ABC-12345",
            PayeeId = 2,
            Type = PaymentType.REGULAR,
            BatchId = 1,
        };

        // Act

        var result = payment.Equals(duplicate);

        // Assert

        Assert.True(result);
    }

    [Fact]
    public void ReturnFalseWhenTwoPaymentsAreNotEqual()
    {
        // Arrange

        var payment = new Payment
        {
            Id = 1,
            Timestamp = new DateTime(2026, 3, 27, 1, 0, 0),
            Amount = 999.99M,
            Reference = "ABC-12345",
            PayeeId = 1,
            Type = PaymentType.REGULAR,
            BatchId = 1,
        };

        var duplicate = new Payment
        {
            Id = 2,
            Timestamp = new DateTime(2026, 3, 27, 3, 0, 0),
            Amount = 999.99M,
            Reference = "ABC-12340",
            PayeeId = 2,
            Type = PaymentType.REGULAR,
            BatchId = 1,
        };

        // Act

        var result = payment.Equals(duplicate);

        // Assert

        Assert.False(result);
    }
}
