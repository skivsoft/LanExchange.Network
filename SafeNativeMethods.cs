using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace LanExchange.Network
{
    internal static class SafeNativeMethods
    {
        internal const string NetApi32 = "netapi32.dll";

        public const uint MAX_PREFERRED_LENGTH = 0xFFFFFFFF;

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetWkstaGetInfo(string servername, int level, out IntPtr bufptr);

        [DllImport(NetApi32, SetLastError = true)]
        internal static extern NetResult NetApiBufferFree(IntPtr bufptr);

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetServerEnum(string server, uint level, out IntPtr bufPtr, uint prefMaxLen,
             out uint entriesRead, out uint totalEntries, uint serverType, string domain, ref uint resume);

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetServerEnumEx(string server, uint level, out IntPtr bufPtr, uint prefMaxLen,
             out uint entriesRead, out uint totalEntries, uint serverType, string domain, string firstNameToReturn);

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetServerGetInfo(string server, uint level, out IntPtr bufPtr);

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetServerSetInfo(string server, uint level, IntPtr buffer, out uint paramError);

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetShareEnum(string server, uint level, out IntPtr bufPtr, uint prefMaxLen,
             out uint entriesRead, out uint totalEntries, ref uint resumeHandle);

        [DllImport(NetApi32, CharSet = CharSet.Unicode)]
        internal static extern NetResult NetWkstaUserEnum(string server, uint level, out IntPtr bufPtr, uint prefMaxLen,
            out uint entriesRead, out uint totalEntries, ref uint resumeHandle);
    }
}