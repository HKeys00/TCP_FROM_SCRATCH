using System.Runtime.InteropServices;
using System.Net;

namespace Shared.WinSock
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SockAddr
    {
        public AddressFamilies Family;

        public short Port;

        public AddressIP4 IpAddress;

        private Int64 Zero;

        public SockAddr(AddressFamilies family, short port, AddressIP4 ip)
        {
            Family = family;
            Port = IPAddress.HostToNetworkOrder(port);
            IpAddress = ip;
            Zero = 0;
        }
    }
}
