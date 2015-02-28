using System;
using System.Runtime.InteropServices;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// SERVER_INFO_100 structure.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [CLSCompliant(false)]
    public class ServerInfo100 : IServerInfo
    {
        /// <summary>
        /// The platform identifier.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        private readonly ServerPlatform m_PlatformId;
        /// <summary>
        /// String specifying the name of a server.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInfo100"/> class.
        /// </summary>
        public ServerInfo100()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInfo100"/> class.
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="name">The name.</param>
        public ServerInfo100(ServerPlatform platformId, string name)
        {
            m_PlatformId = platformId;
            m_Name = name;
        }

        /// <summary>
        /// Gets the platform identifier.
        /// </summary>
        /// <value>
        /// The platform identifier.
        /// </value>
        public ServerPlatform PlatformId
        {
            get { return m_PlatformId; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return m_Name; }
        }
    }
}