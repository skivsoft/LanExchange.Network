namespace LanExchange.Network.Models
{
    /// <summary>
    /// The ServerInfo interface.
    /// </summary>
    public interface IServerInfo
    {
        /// <summary>
        /// Gets the platform identifier.
        /// </summary>
        /// <value>
        /// The platform identifier.
        /// </value>
        ServerPlatform PlatformId { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
    }
}