using Domain;

namespace Infrastructure;

public interface ICardRepository
{
    public Card CreateCard(string? cardNumber, decimal amount);
    public Card GetCardByNumber(string? cardNumber);
    public bool UpdateBalance(string? cardNumber, decimal amount);
}

public class InMemoryCardRepository : ICardRepository
{
    private readonly Dictionary<string, Card> _cards = new();

    public Card CreateCard(string? cardNumber, decimal amount)
    {
        var card = new Card
        {
            CardNumber = cardNumber,
            Balance = amount
        };
        if (card.CardNumber != null) _cards[card.CardNumber] = card;
        return card;
    }

    public Card GetCardByNumber(string? cardNumber)
    {
        return (cardNumber != null && _cards.ContainsKey(cardNumber) ? _cards[cardNumber] : null) ??
               throw new InvalidOperationException();
    }

    public bool UpdateBalance(string? cardNumber, decimal amount)
    {
        if (cardNumber != null && !_cards.ContainsKey(cardNumber)) return false;
        if (cardNumber == null) return false;
        var card = _cards[cardNumber];
        card.Balance += amount;
        return true;
    }
}