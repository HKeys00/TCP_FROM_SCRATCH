using Shared;
using Shared.WinSock;
using System.Drawing;
using System.Runtime.InteropServices;

Socket socket = new Socket();

var address = new SockAddr(AddressFamilies.AF_INET, 5555, AddressIP4.Loopback);

var errors = socket.WsaStartup(2, out var data);

var m = socket.GetLastError();
var s = socket.SocketCreate(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
m = socket.GetLastError();
var t = socket.Bind(s, ref address, Marshal.SizeOf(address));
m = socket.GetLastError();
var l = socket.Listen(s, 1);
m = socket.GetLastError();

int bufferLength = 1024;
unsafe
{
    int* buffer = stackalloc int[bufferLength];
    while (true)
    {
        var connected = socket.Accept(s, IntPtr.Zero, 0);

        m = socket.GetLastError();
        var received = socket.Receive(s, (IntPtr)buffer, bufferLength);
        m = socket.GetLastError();

        var r = 0;
    }
}

