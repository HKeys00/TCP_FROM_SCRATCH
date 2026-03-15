using System.Runtime.InteropServices;

namespace Shared.WinSock.Address
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AddressIPv4
    {
        public byte a1;
        public byte a2;
        public byte a3;
        public byte a4;

        public static AddressIPv4 Broadcast => new AddressIPv4(255, 255, 255, 255);

        public static AddressIPv4 AnyAddress => new AddressIPv4(0, 0, 0, 0);

        public static AddressIPv4 Loopback => new AddressIPv4(127, 0, 0, 1);

        public AddressIPv4(byte a1,  byte a2, byte a3, byte a4)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.a4 = a4;
        }

    }
}
