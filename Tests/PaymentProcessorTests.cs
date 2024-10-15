using Service;

namespace Tests;

[TestClass]
public class PaymentProcessorTests
{
    [TestMethod]
    public void ProcessPayment_WithZeroFee_ReturnsPaymentAmount()
    {
        // Arrange
        var paymentAmount = 100m;
        var paymentProcessor = new PaymentProcessor();
        var fee = 0m;
        UfeService.Instance.SetCurrentFee(fee);

        // Act
        var result = paymentProcessor.ProcessPayment(paymentAmount);

        // Assert
        Assert.AreEqual(paymentAmount, result);
    }

    [TestMethod]
    public void ProcessPayment_WithPositiveFee_ReturnsPaymentAmountWithFeeApplied()
    {
        // Arrange
        var paymentAmount = 100m;
        var fee = 2m;
        UfeService.Instance.SetCurrentFee(fee);
        var paymentProcessor = new PaymentProcessor();

        // Act
        var result = paymentProcessor.ProcessPayment(paymentAmount);

        // Assert
        var expectedAmount = paymentAmount * fee;
        Assert.AreEqual(expectedAmount, result);
    }
}