using System;
using System.Runtime.InteropServices;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// SERVER_INFO_103 structure.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [CLSCompliant(false)]
    public class ServerInfo103 : ServerInfo102
    {
        [MarshalAs(UnmanagedType.U4)] 
        private uint m_Capabilities;

        public uint Capabilities
        {
            get { return m_Capabilities; }
        }
    }
}