using System.Runtime.InteropServices;
using System.Net;
using Shared.WinSock.Enums;

namespace Shared.WinSock.Address
{
    /// <summary>
    /// Represents a native IPv4 socket address structure used by WinSock.
    /// This struct mirrors the layout of the native sockaddr_in structure
    /// so it can be passed directly to WinSock functions such as bind(),
    /// connect(), and accept().
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SockAddress
    {
        /// <summary>
        /// The address family of the socket.
        /// Typically AF_INET for IPv4.
        /// </summary>
        public AddressFamilies Family;

        /// <summary>
        /// The port number in network byte order (big-endian).
        /// Conversion from host byte order is handled in the constructor.
        /// </summary>
        public short Port;

        /// <summary>
        /// The IPv4 address associated with the socket.
        /// For example: Loopback (127.0.0.1) or Any (0.0.0.0).
        /// </summary>
        public AddressIPv4 IpAddress;

        /// <summary>
        /// Padding bytes to match the size of the native sockaddr_in structure.
        /// This field is unused but required for correct memory layout when
        /// interacting with unmanaged WinSock APIs.
        /// </summary>
        private long Zero;

        /// <summary>
        /// Initializes a new socket address with the specified family, port, and IPv4 address.
        /// The port is automatically converted from host byte order to network byte order.
        /// </summary>
        /// <param name="family">Address family (typically AF_INET).</param>
        /// <param name="port">Port number in host byte order.</param>
        /// <param name="ip">IPv4 address.</param>
        public SockAddress(AddressFamilies family, short port, AddressIPv4 ip)
        {
            Family = family;
            Port = IPAddress.HostToNetworkOrder(port);
            IpAddress = ip;
            Zero = 0;
        }
    }
}