namespace Service;

public class PaymentProcessor
{
    public decimal ProcessPayment(decimal paymentAmount)
    {
        var fee = UfeService.Instance.GetCurrentFee();
        var finalAmount = paymentAmount;
        if (fee > 0)
            finalAmount = paymentAmount * fee;
        return finalAmount;
    }
}