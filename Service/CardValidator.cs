namespace Service;

public class CardValidator
{
    /// <summary>
    ///     Check if the card number is exactly 15 digits
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    public static string ValidateCardNumber(string cardNumber)
    {
        if (cardNumber.Length == 15 && long.TryParse(cardNumber, out _))
            return "Card number is valid.";
        return "Invalid card number. It must be exactly 15 digits.";
    }
}