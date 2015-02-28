using System;
using System.Diagnostics.CodeAnalysis;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// The information level to use for platform-specific information.
    /// </summary>
    [CLSCompliant(false)]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum ServerPlatform : uint
    {
        /// <summary>
        /// Server platform is not specified.
        /// </summary>
        None,
        /// <summary>
        /// The MS-DOS platform.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DOS")]
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
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OSF")]
        OSF = 600,
        /// <summary>
        /// The VMS platform.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "VMS")]
        VMS = 700
    }
}