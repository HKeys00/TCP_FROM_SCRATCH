using System;
using System.Runtime.InteropServices;
namespace Shared.WinSock
{
    public class Socket
    {
        [DllImport("ws2_32.dll")]
        public static extern int bind(nint socket, ref SockAddr address, int addressSize);

        [DllImport("ws2_32.dll")]
        public static extern int recv(nint socket, nint buf, int len, SendDataFlags flags);

        [DllImport("ws2_32.dll")]
        public static extern int send(nint socket, nint buff, int len, SendDataFlags flags, ref SockAddr to, nint toLength);

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto)]
        static extern Int32 WSAGetLastError();
        
        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Int32 WSAStartup(Int16 wVersionRequested, out WSAData wsaData);

        [DllImport("ws2_32.dll")]
        static extern IntPtr socket(AddressFamilies family, SocketType type, short protocol);

        [DllImport("ws2_32.dll")]
        static extern int connect(IntPtr socket, ref SockAddr address, nint length);

        [DllImport("Ws2_32.dll", CharSet = CharSet.Unicode, EntryPoint = "InetPtonW")]
        static extern IntPtr inet_pton(AddressFamilies family, string address, ref AddressIP4 buffer);

        [DllImport("Ws2_32.dll")]
        static extern IntPtr listen(IntPtr socket, int backlog);

        [DllImport("Ws2_32.dll")]
        static extern IntPtr accept(IntPtr socket, IntPtr address, int addressSize);

        public int Bind(nint socket, ref SockAddr address, int addressSize)
        {
            return bind(socket, ref address, addressSize);
        }

        public int Receive(nint socket, nint buffer, int length)
        {
            return recv(socket, buffer, length, SendDataFlags.None);
        }

        public int SendTo(nint socket, nint buffer, int length, ref SockAddr to, nint toLength)
        {
            return send(socket, buffer, length, SendDataFlags.None, ref to, toLength);
        }

        public IntPtr Listen(nint socket, int backlog)
        {
            return listen(socket, backlog);
        }

        public IntPtr Accept(nint socket, nint address, int size)
        {
            return accept(socket, address, size);
        }

        public Int32 GetLastError()
        {
            return WSAGetLastError();
        }

        public Int32 WsaStartup(Int16 version, out WSAData data)
        {
            return WSAStartup(version, out data);
        }

        public IntPtr SocketCreate(AddressFamilies family, SocketType type, short protocol)
        {
            return socket(family, type, protocol);
        }

        public Int32 ConnectTo(IntPtr socket , ref SockAddr address, int addressSize)
        {
            return connect(socket, ref address, addressSize);
        }

        public IntPtr Inet(AddressFamilies family, string address, ref AddressIP4 buffer)
        {
            return inet_pton(family, address, ref buffer);
        }

    }
}