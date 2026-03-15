using System.Runtime.InteropServices;
using System.Net;
using Shared.WinSock.Enums;

namespace Shared.WinSock.Address
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SockAddr
    {
        public AddressFamilies Family;

        public short Port;

        public AddressIP4 IpAddress;

        private long Zero;

        public SockAddr(AddressFamilies family, short port, AddressIP4 ip)
        {
            Family = family;
            Port = IPAddress.HostToNetworkOrder(port);
            IpAddress = ip;
            Zero = 0;
        }
    }
}
