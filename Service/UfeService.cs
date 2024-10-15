using System.Timers;
using Timer = System.Timers.Timer;

namespace Service;

public class UfeService
{
    private static readonly Lazy<UfeService> UfeServiceInstance = new(() => new UfeService());
    private decimal _currentFee;
    private readonly Random _random;
    private readonly int _feeUpdateInterval = 3600000; // 1 hour

    private UfeService()
    {
        _currentFee = 0;
        _random = new Random();
        var feeUpdateTimer = new Timer(_feeUpdateInterval);
        feeUpdateTimer.Elapsed += UpdateFee;
        feeUpdateTimer.Start();
    }

    public static UfeService Instance => UfeServiceInstance.Value;

    public decimal GetCurrentFee()
    {
        return _currentFee;
    }

    private void UpdateFee(object? sender, ElapsedEventArgs e)
    {
        decimal randomFactor = _random.Next(0, 2) * 2;
        _currentFee = randomFactor;
    }

    internal void SetCurrentFee(decimal fee)
    {
        _currentFee = fee;
    }
}