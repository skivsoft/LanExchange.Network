using System;
using System.Runtime.InteropServices;

namespace LanExchange.Network.Models
{
    /// <summary>
    /// SERVER_INFO_102 structure.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [CLSCompliant(false)]
    public class ServerInfo102 : ServerInfo101
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint sv102_users;
        [MarshalAs(UnmanagedType.I4)]
        public int sv102_disc;
        [MarshalAs(UnmanagedType.U1)]
        public bool sv102_hidden;
        [MarshalAs(UnmanagedType.U4)]
        public uint sv102_announce;
        [MarshalAs(UnmanagedType.U4)]
        public uint sv102_anndelta;
        [MarshalAs(UnmanagedType.U4)]
        public uint sv102_licenses;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string sv102_userpath;
    }
}