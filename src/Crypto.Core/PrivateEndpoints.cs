namespace Crypto.Core;

public static class PrivateEndpoints
{
    /*------------------------ User Data ----------------------*/

    /// <summary>
    /// Retrieve all cash balances, net of pending withdrawals
    /// </summary>
    public const string Balance = "/private/Balance";

    /// <summary>
    /// Retrieve a summary of collateral balances, margin position valuations, equity and margin level
    /// </summary>
    public const string TradeBalance = "/private/TradeBalance";

    /// <summary>
    /// Retrieve information about currently open orders
    /// </summary>
    public const string OpenOrders = "/private/OpenOrders";

    /// <summary>
    /// Retrieve information about orders that have been closed (filled or cancelled).
    /// 50 results are returned at a time, the most recent by default
    /// 
    /// Note: If an order's tx ID is given for start or end time, the order's opening time (opentm) is used
    /// </summary>
    public const string ClosedOrders = "/private/ClosedOrders";

    /// <summary>
    /// Retrieve information about specific orders
    /// </summary>
    public const string QueryOrders = "/private/QueryOrders";

    /// <summary>
    /// Retrieve information about trades/fills.
    /// 50 results are returned at a time, the most recent by default
    /// 
    /// Unless otherwise stated, costs, fees, prices, and volumes are specified
    /// with the precision for the asset pair (pair_decimals and lot_decimals),
    /// not the individual assets' precision (decimals)
    /// </summary>
    public const string TradesHistory = "/private/TradesHistory";

    /// <summary>
    /// Retrieve information about specific trades/fills.
    /// </summary>
    public const string QueryTrades = "/private/QueryTrades";

    /// <summary>
    /// Get information about open margin positions.
    /// </summary>
    public const string OpenPositions = "/private/OpenPositions";

    /// <summary>
    /// Retrieve information about ledger entries. 50 results are returned at a time, the most recent by default.
    /// </summary>
    public const string Ledgers = "/private/Ledgers";

    /// <summary>
    /// Retrieve information about specific ledger entries.
    /// </summary>
    public const string QueryLedgers = "/private/QueryLedgers";

    /// <summary>
    /// Get Trade Volume
    /// </summary>
    public const string TradeVolume = "/private/TradeVolume";

    /// <summary>
    /// Request Export Report
    /// </summary>
    public const string AddExport = "/private/AddExport";

    /// <summary>
    /// Get status of requested data exports
    /// </summary>
    public const string ExportStatus = "/private/ExportStatus";

    /// <summary>
    /// Retrieve a processed data export
    /// </summary>
    public const string RetrieveExport = "/private/RetrieveExport";

    /// <summary>
    /// Delete exported trades/ledgers report
    /// </summary>
    public const string RemoveExport = "/private/RemoveExport";


    /*------------------------ User Trading ----------------------*/

    /// <summary>
    /// Place a new order.
    /// </summary>
    public const string AddOrder = "/private/AddOrder";

    /// <summary>
    /// Cancel a particular open order (or set of open orders) by txid or userref
    /// </summary>
    public const string CancelOrder = "/private/CancelOrder";

    /// <summary>
    /// Cancel all open orders
    /// </summary>
    public const string CancelAll = "/private/RetrieveExport";

    /// <summary>
    /// CancelAllOrdersAfter provides a "Dead Man's Switch" mechanism to protect
    /// the client from network malfunction, extreme latency or unexpected matching engine downtime.
    /// The client can send a request with a timeout (in seconds),
    /// that will start a countdown timer which will cancel all client orders when the timer expires.
    /// The client has to keep sending new requests to push back the trigger time,
    /// or deactivate the mechanism by specifying a timeout of 0.
    /// If the timer expires, all orders are cancelled and then the timer
    /// remains disabled until the client provides a new (non-zero) timeout.
    /// 
    /// The recommended use is to make a call every 15 to 30 seconds, providing a timeout of 60 seconds.
    /// This allows the client to keep the orders in place in case of a brief disconnection or transient delay,
    /// while keeping them safe in case of a network breakdown.
    /// It is also recommended to disable the timer ahead of regularly scheduled trading engine maintenance
    /// (if the timer is enabled, all orders will be cancelled when the trading engine comes back from downtime - planned or otherwise)
    /// </summary>
    public const string CancelAllOrdersAfter = "/private/CancelAllOrdersAfter";


    /*------------------------ User Funding ----------------------*/

    /// <summary>
    /// Retrieve methods available for depositing a particular asset
    /// </summary>
    public const string DepositMethods = "/private/DepositMethods";

    /// <summary>
    /// Retrieve (or generate a new) deposit addresses for a particular asset and method
    /// </summary>
    public const string DepositAdresses = "/private/DepositAdresses";

    /// <summary>
    /// Retrieve information about recent deposits made.
    /// </summary>
    public const string DepositStatus = "/private/DepositStatus";

    /// <summary>
    /// Retrieve fee information about potential withdrawals for a particular asset, key and amount
    /// </summary>
    public const string WithdrawInfo = "/private/WithdrawInfo";

    /// <summary>
    /// Make a withdrawal request
    /// </summary>
    public const string Withdraw = "/private/Withdraw";

    /// <summary>
    /// Retrieve information about recently requests withdrawals
    /// </summary>
    public const string WithdrawStatus = "/private/WithdrawStatus";

    /// <summary>
    /// Cancel a recently requested withdrawal, if it has not already been successfully processed
    /// </summary>
    public const string WithdrawCancel = "/private/WithdrawCancel";

    /// <summary>
    /// Transfer from Kraken spot wallet to Kraken Futures holding wallet.
    /// Note that a transfer in the other direction must be requested via the Kraken Futures API endpoint
    /// </summary>
    public const string WalletTransfer = "/private/WalletTransfer";


    /*------------------------ User Staking ----------------------*/

    /// <summary>
    /// Stake an asset from your spot wallet.
    /// This operation requires an API key with Withdraw funds permission
    /// </summary>
    public const string Stake = "/private/Stake";

    /// <summary>
    /// Unstake an asset from your staking wallet.
    /// This operation requires an API key with Withdraw funds permission
    /// </summary>
    public const string Unstake = "/private/Unstake";

    /// <summary>
    /// Returns the list of assets that the user is able to stake.
    /// This operation requires an API key with both Withdraw funds and Query funds permission
    /// </summary>
    public const string StakingAssets = "/private/Staking/Assets";

    /// <summary>
    /// Returns the list of pending staking transactions.
    /// Once resolved, these transactions will appear on the List of Staking Transactions endpoint
    /// 
    /// This operation requires an API key with both Query funds and Withdraw funds permissions
    /// </summary>
    public const string StakingPending = "/private/Staking/Pending";

    /// <summary>
    /// Returns the list of all staking transactions.
    /// This endpoint can only return up to 1000 of the most recent transactions
    /// 
    /// This operation requires an API key with Query funds permissions
    /// </summary>
    public const string StakingTransactions = "/private/Staking/Transactions";
}