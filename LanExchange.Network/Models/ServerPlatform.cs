using System;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// The information level to use for platform-specific information.
    /// </summary>
    [CLSCompliant(false)]
    public enum ServerPlatform : uint
    {
        /// <summary>
        /// The MS-DOS platform.
        /// </summary>
        DOS = 300,
        /// <summary>
        /// The OS/2 platform.
        /// </summary>
        OS2 = 400,
        /// <summary>
        /// The Windows NT platform.
        /// </summary>
        NT = 500,
        /// <summary>
        /// The OSF platform.
        /// </summary>
        OSF = 600,
        /// <summary>
        /// The VMS platform.
        /// </summary>
        VMS = 700
    }
}