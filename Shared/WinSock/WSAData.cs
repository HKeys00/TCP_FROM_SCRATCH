namespace Shared.WinSock
{
    public unsafe struct WSAData
    {
        public ushort wVersion;
        public ushort wHighVersion;

        public fixed byte szDescription[257];
        public fixed byte szSystemStatus[129];

        public ushort iMaxSockets;
        public ushort iMaxUdpDg;
        IntPtr lpVendorInfo;
    }
}
