namespace Crypto.Core;

public static class PublicEndpoints
{
    /// <summary>
    /// Get the server's time
    /// </summary>
    public const string ServerTime = "/public/Time";

    /// <summary>
    /// Get the current system status or trading mode
    /// </summary>
    public const string SystemStatus = "/public/SystemStatus";

    /// <summary>
    /// Get information about the assets that are available for deposit, withdrawal, trading and staking
    /// </summary>
    public const string AssetInfo = "/public/Assets";

    /// <summary>
    /// Get tradable asset pairs
    /// </summary>
    public const string AssetPairs = "/public/Assets";

    /// <summary>
    /// Get Ticker Information
    /// </summary>
    public const string Ticker = "/public/Ticker";

    /// <summary>
    /// Get OHLC Data
    /// </summary>
    public const string OHLC = "/public/OHLC";

    /// <summary>
    /// Get Order Book
    /// </summary>
    public const string Depth = "/public/Depth";

    /// <summary>
    /// Get Recent Trades
    /// </summary>
    public const string Trades = "/public/Trades";

    /// <summary>
    /// Get Recent Spreads
    /// </summary>
    public const string Spread = "/public/Spread";
}