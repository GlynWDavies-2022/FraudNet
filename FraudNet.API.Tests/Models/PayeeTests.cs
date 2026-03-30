using FraudNet.API.Data.Implementations;
using FraudNet.API.Models.Payee;

namespace FraudNet.API.Tests.Models;

public class PayeeShould
{
    [Fact]
    public void ReturnCorrectNewId()
    {
        // Arrange

        var sut = new PayeeDataStore();

        // Act

        var newId = sut.GetNextId();

        // Assert

        Assert.Equal(6, newId);
    }
}
