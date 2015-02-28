namespace LanExchange.Network
{
    internal enum NetResult
    {
        Success = 0,
        AccessDenied = 5,
        NotEnoughMemory = 8,
        BadNetworkPath = 53,
        NetworkBusy = 54,
        InvalidParameter = 87,
        InvalidLevel = 124,
        MoreData = 234,
        ExtendedError = 1208,
        NoNetwork = 1222,
        InvalidHandleState = 1609,
        NoBrowserServersFound = 6118
    }
}