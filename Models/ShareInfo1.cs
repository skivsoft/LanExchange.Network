using System;
using System.Runtime.InteropServices;

namespace LanExchange.Network.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [CLSCompliant(false)]
    public sealed class ShareInfo1 : IShareInfo
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_NetName;
        [MarshalAs(UnmanagedType.U4)]
        private readonly ShareTypes m_ShareType;
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_Remark;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareInfo1"/> class.
        /// </summary>
        public ShareInfo1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareInfo1"/> class.
        /// </summary>
        /// <param name="netName">Name of the net.</param>
        /// <param name="shareType">Type of the share.</param>
        /// <param name="remark">The remark.</param>
        public ShareInfo1(string netName, ShareTypes shareType, string remark)
        {
            m_NetName = netName;
            m_ShareType = shareType;
            m_Remark = remark;
        }

        public string NetName
        {
            get { return m_NetName; }
        }

        public ShareTypes ShareType
        {
            get { return m_ShareType; }
        }

        public string Remark
        {
            get { return m_Remark; }
        }
    }
}