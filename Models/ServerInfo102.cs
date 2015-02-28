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
        private readonly uint m_LogOnUsers;
        [MarshalAs(UnmanagedType.I4)]
        private readonly int m_AutoDisconnect;
        [MarshalAs(UnmanagedType.U1)]
        private readonly bool m_IsHidden;
        [MarshalAs(UnmanagedType.U4)]
        private readonly uint m_Announce;
        [MarshalAs(UnmanagedType.U4)]
        private readonly uint m_AnnounceDelta;
        [MarshalAs(UnmanagedType.U4)]
        private readonly uint m_UsersPerLicense;
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_UserPath;

        public uint LogOnUsers
        {
            get {  return m_LogOnUsers; }
        }

        public int AutoDisconnect
        {
            get {  return m_AutoDisconnect; }
        }

        public bool IsHidden
        {
            get {  return m_IsHidden; }
        }

        public uint Announce
        {
            get { return m_Announce; }
        }

        public uint AnnounceDelta
        {
            get { return m_AnnounceDelta; }
        }

        public uint UsersPerLicense
        {
            get {  return m_UsersPerLicense; }
        }

        public string UserPath
        {
            get { return m_UserPath; }
        }
    }
}