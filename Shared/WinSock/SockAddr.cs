using System.Runtime.InteropServices;

namespace Shared.WinSock
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SockAddr
    {
        public AddressFamilies Family;

        public ushort Port;

        public AddressIP4 IpAddress;

        private Int64 Zero;

        public SockAddr(AddressFamilies family, ushort port, AddressIP4 ip)
        {
            Family = family;
            Port = port;
            IpAddress = ip;
            Zero = 0;
        }
    }
}
