using Domain;
using Infrastructure;

namespace Service;

public class CardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public string CreateCard(string cardNumber, decimal amount)
    {
        var validator = CardValidator.ValidateCardNumber(cardNumber);
        if (validator != "Card number is valid.") return validator;
        _cardRepository.CreateCard(cardNumber, amount);
        return "Card created successfully.";
    }

    public Card GetCardBalance(string? cardNumber)
    {
        return _cardRepository.GetCardByNumber(cardNumber);
    }

    public bool Pay(string? cardNumber, decimal amount)
    {
        var card = _cardRepository.GetCardByNumber(cardNumber);
        if (card == null || card.Balance < amount) return false;
        return _cardRepository.UpdateBalance(cardNumber, -amount);
    }

    public bool UpdateCardBalance(string? cardNumber, decimal amount)
    {
        return _cardRepository.UpdateBalance(cardNumber, amount);
    }
}