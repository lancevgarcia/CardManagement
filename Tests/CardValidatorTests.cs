using Service;

namespace Tests;

[TestClass]
public class CardValidatorTests
{
    [TestMethod]
    public void ValidateCardNumber_ValidCardNumber_ReturnsValidMessage()
    {
        // Arrange
        var cardNumber = "123456789012345";

        // Act
        var result = CardValidator.ValidateCardNumber(cardNumber);

        // Assert
        Assert.AreEqual("Card number is valid.", result);
    }

    [TestMethod]
    public void ValidateCardNumber_InvalidCardNumber_ReturnsInvalidMessage()
    {
        // Arrange
        var cardNumber = "12345678901234";

        // Act
        var result = CardValidator.ValidateCardNumber(cardNumber);

        // Assert
        Assert.AreEqual("Invalid card number. It must be exactly 15 digits.", result);
    }
}