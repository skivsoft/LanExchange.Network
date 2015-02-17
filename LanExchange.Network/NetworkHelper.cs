using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LanExchange.Network.Models;

namespace LanExchange.Network
{
    /// <summary>
    /// Network api helper.
    /// </summary>
    public static class NetworkHelper
    {
        /// <summary>
        /// Get list of serves of specified domain and specified types.
        /// </summary>
        /// <typeparam name="TServerInfo">The type of the server information.</typeparam>
        /// <param name="level">The level.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static IEnumerable<TServerInfo> NetServerEnum<TServerInfo>(uint level, string domain, SoftwareTypes types) where TServerInfo : ServerInfo100, new()
        {
            NetResult enumResult;
            var itemSize = Marshal.SizeOf(typeof(TServerInfo));
            string resume = null;
            do
            {
                IntPtr bufPtr;
                uint entriesread;
                uint totalentries;
                enumResult = SafeNativeMethods.NetServerEnumEx(null, level, out bufPtr, SafeNativeMethods.MAX_PREFERRED_LENGTH, out entriesread, out totalentries, (uint)types, domain, resume);
                if (enumResult == NetResult.Success || enumResult == NetResult.MoreData)
                {
                    var ptr = bufPtr;
                    for (var i = 0; i < entriesread; i++)
                    {
                        // skip start server when resuming
                        if (i == 0 && resume != null)
                            continue;

                        // return current item
                        var item = new TServerInfo();
                        if (i > 0)
                            ptr = (IntPtr) (ptr.ToInt64() + itemSize);
                        Marshal.PtrToStructure(ptr, item);
                        yield return item;

                        if (i == entriesread - 1)
                            resume = item.Name;
                    }
                    var freeResult = SafeNativeMethods.NetApiBufferFree(bufPtr);
                    if (freeResult != (int) NetResult.Success)
                        break;
                }
            } while (enumResult == NetResult.MoreData);
        }

        /// <summary>
        /// Nets the server get information.
        /// </summary>
        /// <typeparam name="TServerInfo">The type of the server information.</typeparam>
        /// <param name="server">The server.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public static TServerInfo NetServerGetInfo<TServerInfo>(string server, uint level) where TServerInfo : ServerInfo100, new()
        {
            IntPtr bufPtr;
            var getResult = SafeNativeMethods.NetServerGetInfo(server, level, out bufPtr);
            if (getResult != NetResult.Success)
                return null;
            
            var result = new TServerInfo();
            Marshal.PtrToStructure(bufPtr, result);

            var freeResult = SafeNativeMethods.NetApiBufferFree(bufPtr);

            return result;
        }

        /// <summary>
        /// Nets the server set information.
        /// </summary>
        /// <typeparam name="TServerInfo">The type of the server information.</typeparam>
        /// <param name="server">The server.</param>
        /// <param name="level">The level.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="Win32Exception"></exception>
        public static void NetServerSetInfo<TServerInfo>(string server, uint level, TServerInfo data) where TServerInfo : ServerInfo100
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            try
            {
                uint error;
                Marshal.StructureToPtr(data, ptr, false);
                var setResult = SafeNativeMethods.NetServerSetInfo(server, level, ptr, out error);
                if (setResult != (int)NetResult.Success)
                    throw new Win32Exception((int)setResult);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Nets the share enum.
        /// </summary>
        /// <param name="computer">The computer.</param>
        /// <returns></returns>
        public static IEnumerable<SHARE_INFO_1> NetShareEnum(string computer)
        {
            const uint stypeIpc = (uint)SHARE_TYPE.STYPE_IPC;
            uint resumeHandle = 0;
            NetResult enumResult;
            var itemSize = Marshal.SizeOf(typeof (SHARE_INFO_1));
            var result = new List<SHARE_INFO_1>();

            do
            {
                IntPtr bufPtr;
                uint entriesread;
                uint totalentries;
                enumResult = SafeNativeMethods.NetShareEnum(computer, 1, out bufPtr, SafeNativeMethods.MAX_PREFERRED_LENGTH,
                    out entriesread, out totalentries, ref resumeHandle);
                if (enumResult == NetResult.Success || enumResult == NetResult.MoreData)
                {
                    var ptr = bufPtr;
                    for (int i = 0; i < entriesread; i++)
                    {
                        var shi1 = new SHARE_INFO_1();
                        if (i > 0)
                            ptr = (IntPtr)(ptr.ToInt64() + itemSize);
                        Marshal.PtrToStructure(ptr, shi1);
                        if ((shi1.type & stypeIpc) != stypeIpc)
                            result.Add(shi1);
                    }
                    var freeResult = SafeNativeMethods.NetApiBufferFree(bufPtr);
                    if (freeResult != (int) NetResult.Success)
                        break;
                }
            } while (enumResult == NetResult.MoreData);
            return result;
        }

        /// <summary>
        /// Nets the workstation user enum.
        /// </summary>
        /// <param name="computer">The computer.</param>
        /// <returns></returns>
        public static IEnumerable<WKSTA_USER_INFO_1> NetWorkstationUserEnum(string computer)
        {
            uint resumehandle = 0;
            NetResult enumResult;
            var itemSize = Marshal.SizeOf(typeof (WKSTA_USER_INFO_1));
            var result = new List<WKSTA_USER_INFO_1>();
            do
            {
                IntPtr bufPtr;
                uint entriesread;
                uint totalentries;
                enumResult = SafeNativeMethods.NetWkstaUserEnum(computer, 1, out bufPtr, SafeNativeMethods.MAX_PREFERRED_LENGTH, 
                    out entriesread, out totalentries, ref resumehandle);
                switch (enumResult)
                {
                    case NetResult.MoreData:
                    case NetResult.Success:
                        var ptr = bufPtr;
                        for (int i = 0; i < entriesread; i++)
                        {
                            var item = new WKSTA_USER_INFO_1();
                            if (i > 0)
                                ptr = (IntPtr)(ptr.ToInt64() + itemSize);
                            Marshal.PtrToStructure(ptr, item);
                            result.Add(item);
                        }
                        SafeNativeMethods.NetApiBufferFree(bufPtr);
                        break;
                }
            } while (enumResult == NetResult.MoreData);
            return result;
        }
    }
}