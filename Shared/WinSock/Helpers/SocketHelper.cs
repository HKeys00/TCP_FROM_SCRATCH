using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using System.Runtime.InteropServices;
namespace Shared.WinSock
{
    public class SocketHelper
    {
        [DllImport("Ws2_32.dll", CharSet = CharSet.Unicode, EntryPoint = "InetPtonW")]
        static extern IntPtr inet_pton(AddressFamilies family, string address, ref AddressIPv4 buffer);

        /// <summary>
        /// Converts an IPv4 address into numeric binary form
        /// </summary>
        /// <param name="family">The address family.</param>
        /// <param name="address">The address string.</param>
        /// <param name="buffer">The reference to the IPv4 address.</param>
        /// <returns>The numeric binary form of the address.</returns>
        public static IntPtr Inet(AddressFamilies family, string address, ref AddressIPv4 buffer)
        {
            return inet_pton(family, address, ref buffer);
        }
    }
}