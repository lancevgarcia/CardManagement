namespace Domain;

public class Card
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? CardNumber { get; set; }
    public decimal Balance { get; set; } = 0.0M;
}