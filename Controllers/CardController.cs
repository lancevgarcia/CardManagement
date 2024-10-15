using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly CardService _cardService;

    public CardController(CardService cardService)
    {
        _cardService = cardService;
    }

    [Authorize]
    [HttpPost("create")]
    public IActionResult CreateCard(string? cardNumber, decimal amount)
    {
        if (cardNumber == null) return BadRequest("Invalid Card number.");
        var card = _cardService.CreateCard(cardNumber, amount);

        return Ok(card);
    }

    [Authorize]
    [HttpGet("{cardNumber}/balance")]
    public IActionResult GetCardBalance(string? cardNumber)
    {
        var card = _cardService.GetCardBalance(cardNumber);

        return Ok(new { card.Balance });
    }

    [Authorize]
    [HttpPost("{cardNumber}/update")]
    public IActionResult UpdateCardBalance(string? cardNumber, [FromBody] decimal amount)
    {
        var success = _cardService.UpdateCardBalance(cardNumber, amount);
        if (!success) return BadRequest("Update failed");

        return Ok("Update successful");
    }

    [Authorize]
    [HttpPost("{cardNumber}/pay")]
    public IActionResult Pay(string? cardNumber, [FromBody] decimal amount)
    {
        var success = _cardService.Pay(cardNumber, amount);
        if (!success) return BadRequest("Payment failed");

        return Ok("Payment successful");
    }
}