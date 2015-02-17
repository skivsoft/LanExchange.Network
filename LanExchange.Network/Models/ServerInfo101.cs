using System;
using System.Runtime.InteropServices;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// SERVER_INFO_101 structure.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [CLSCompliant(false)]
    public class ServerInfo101 : ServerInfo100
    {
        /// <summary>
        /// The empty ServerInfo.
        /// </summary>
        public static readonly new ServerInfo101 Empty = new ServerInfo101();
        /// <summary>
        /// The major version number and the server type.
        /// The major release version number of the operating system is specified in the least significant 4 bits. 
        /// The server type is specified in the most significant 4 bits.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        private readonly uint m_VersionMajor;
        /// <summary>
        /// The minor release version number of the operating system.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        private readonly uint m_VersionMinor;
        /// <summary>
        /// The type of software the computer is running.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        private readonly SoftwareTypes m_Type;
        /// <summary>
        /// String specifying a comment describing the server. The comment can be null.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_Comment;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInfo101"/> class.
        /// </summary>
        public ServerInfo101()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerInfo101"/> class.
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="versionMajor">The version major.</param>
        /// <param name="versionMinor">The version minor.</param>
        /// <param name="type">The type.</param>
        /// <param name="comment">The comment.</param>
        public ServerInfo101(ServerPlatform platformId, string name, uint versionMajor, uint versionMinor, SoftwareTypes type, string comment) : base(platformId, name)
        {
            m_VersionMajor = versionMajor;
            m_VersionMinor = versionMinor;
            m_Type = type;
            m_Comment = comment;
        }

        /// <summary>
        /// Gets the version major.
        /// </summary>
        /// <value>
        /// The version major.
        /// </value>
        public uint VersionMajor
        {
            get { return m_VersionMajor; }
        }

        /// <summary>
        /// Gets the version minor.
        /// </summary>
        /// <value>
        /// The version minor.
        /// </value>
        public uint VersionMinor
        {
            get { return m_VersionMinor; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public SoftwareTypes Type
        {
            get { return m_Type; }
        }

        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment
        {
            get { return m_Comment; }
        }
    }
}