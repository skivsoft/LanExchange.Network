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
        public static IEnumerable<TServerInfo> NetServerEnum<TServerInfo>(uint level, string domain, SoftwareTypes types) where TServerInfo : IServerInfo, new()
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
                    if (freeResult != NetResult.Success)
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
        public static TServerInfo NetServerGetInfo<TServerInfo>(string server, uint level) where TServerInfo : IServerInfo, new()
        {
            IntPtr bufPtr;
            var getResult = SafeNativeMethods.NetServerGetInfo(server, level, out bufPtr);
            if (getResult != NetResult.Success)
                return default(TServerInfo);
            
            var result = new TServerInfo();
            Marshal.PtrToStructure(bufPtr, result);

            SafeNativeMethods.NetApiBufferFree(bufPtr);

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
        public static void NetServerSetInfo<TServerInfo>(string server, uint level, TServerInfo data) where TServerInfo : IServerInfo
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            try
            {
                uint error;
                Marshal.StructureToPtr(data, ptr, false);
                var setResult = SafeNativeMethods.NetServerSetInfo(server, level, ptr, out error);
                if (setResult != NetResult.Success)
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
        /// <typeparam name="TShareInfo">The type of the share information.</typeparam>
        /// <param name="level">The level.</param>
        /// <param name="computer">The computer.</param>
        /// <returns></returns>
        public static IEnumerable<TShareInfo> NetShareEnum<TShareInfo>(uint level, string computer) where TShareInfo : IShareInfo, new()
        {
            uint resumeHandle = 0;
            NetResult enumResult;
            var itemSize = Marshal.SizeOf(typeof (TShareInfo));
            do
            {
                IntPtr bufPtr;
                uint entriesread;
                uint totalentries;
                enumResult = SafeNativeMethods.NetShareEnum(computer, level, out bufPtr, SafeNativeMethods.MAX_PREFERRED_LENGTH,
                    out entriesread, out totalentries, ref resumeHandle);
                if (enumResult == NetResult.Success || enumResult == NetResult.MoreData)
                {
                    var ptr = bufPtr;
                    for (int i = 0; i < entriesread; i++)
                    {
                        var shareInfo = new TShareInfo();
                        if (i > 0)
                            ptr = (IntPtr)(ptr.ToInt64() + itemSize);
                        Marshal.PtrToStructure(ptr, shareInfo);
                        yield return shareInfo;
                    }
                    var freeResult = SafeNativeMethods.NetApiBufferFree(bufPtr);
                    if (freeResult != NetResult.Success)
                        break;
                }
            } while (enumResult == NetResult.MoreData);
        }

        /// <summary>
        /// Nets the workstation user enum.
        /// </summary>
        /// <param name="computer">The computer.</param>
        /// <returns></returns>
        public static IEnumerable<WorkstationUserInfo> NetWorkstationUserEnum(string computer)
        {
            uint resumehandle = 0;
            NetResult enumResult;
            var itemSize = Marshal.SizeOf(typeof (WorkstationUserInfo));
            var result = new List<WorkstationUserInfo>();
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
                            var item = new WorkstationUserInfo();
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