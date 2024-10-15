using Domain;
using Infrastructure;
using Moq;
using Service;

namespace Tests;

[TestClass]
public class CardServiceTests
{
    private readonly Mock<ICardRepository> _cardRepositoryMock;
    private readonly CardService _cardService;
    private const string CardNumber = "123456789012345";

    public CardServiceTests()
    {
        _cardRepositoryMock = new Mock<ICardRepository>();
        _cardService = new CardService(_cardRepositoryMock.Object);
    }

    [TestMethod]
    public void CreateCard_ShouldCallCreateCardMethod()
    {
        // Arrange
        var amount = 100.00m;

        // Act
        _cardService.CreateCard(CardNumber, amount);

        // Assert
        _cardRepositoryMock.Verify(x => x.CreateCard(CardNumber, amount), Times.Once);
    }

    [TestMethod]
    public void GetCardBalance_ShouldCallGetCardByNumberMethod()
    {
        // Act
        _cardService.GetCardBalance(CardNumber);

        // Assert
        _cardRepositoryMock.Verify(x => x.GetCardByNumber(CardNumber), Times.Once);
    }

    [TestMethod]
    public void UpdateCardBalance_ShouldCallUpdateBalanceMethod()
    {
        // Arrange
        var amount = 100.00m;

        // Act
        _cardService.UpdateCardBalance(CardNumber, amount);

        // Assert
        _cardRepositoryMock.Verify(x => x.UpdateBalance(CardNumber, amount), Times.Once);
    }

    [TestMethod]
    public void Pay_ShouldCallGetCardByNumberMethod()
    {
        // Arrange
        var amount = 100.00m;
        _cardService.CreateCard(CardNumber, amount);
        _cardRepositoryMock.Setup(x => x.GetCardByNumber(CardNumber)).Returns(new Card
        {
            CardNumber = CardNumber,
            Balance = amount
        });
        // Act
        _cardService.Pay(CardNumber, 10);

        // Assert
        _cardRepositoryMock.Verify(x => x.GetCardByNumber(CardNumber), Times.Once);
    }

    [TestMethod]
    public void Pay_ShouldCallUpdateBalanceMethod()
    {
        // Arrange
        var amount = 100.00m;
        _cardService.CreateCard(CardNumber, amount);
        _cardRepositoryMock.Setup(x => x.GetCardByNumber(CardNumber)).Returns(new Card
        {
            CardNumber = CardNumber,
            Balance = amount
        });

        // Act
        _cardService.Pay(CardNumber, 10);

        // Assert
        _cardRepositoryMock.Verify(x => x.UpdateBalance(CardNumber, It.IsAny<decimal>()), Times.Once);
    }
}