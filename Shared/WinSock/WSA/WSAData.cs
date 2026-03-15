using System.Runtime.InteropServices;

namespace Shared.WinSock.WSA
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WSAData
    {
        /// <summary>
        /// The version of the windows sockets specification.
        /// </summary>
        public short version;

        /// <summary>
        /// The highester version of the windows sockets specification that is supported.
        /// </summary>
        public short highVersion;

        /// <summary>
        /// A NULL-terminated ASCII string into which the Ws2_32.dll copies a description of the Windows Sockets implementation.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
        public string description;

        /// <summary>
        /// A NULL-terminated ASCII string into which the Ws2_32.dll copies relevant status or configuration information.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string systemStatus;

        /// <summary>
        /// The maximum number of sockets that may be opened. This member should be ignored for Windows Sockets version 2 and later.
        /// </summary>
        public short maxSockets;

        /// <summary>
        /// The maximum datagram message size. This member is ignored for Windows Sockets version 2 and later.
        /// </summary>
        public short maxUdpDg;

        /// <summary>
        /// A pointer to vendor-specific information. This member should be ignored for Windows Sockets version 2 and later.
        /// </summary>
        public nint vendorInfo;
    }
}
