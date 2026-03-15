using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using Shared.WinSock.Socket;
using System.Runtime.InteropServices;

Socket socket = new Socket();
var address = new SockAddr(AddressFamilies.AF_INET, 5555, AddressIP4.Loopback);
var errors = socket.WsaStartup(2, out var data);
var m = socket.GetLastError();
var s = socket.SocketCreate(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
m = socket.GetLastError();
socket.ConnectTo(s, ref address, Marshal.SizeOf(address));

int bufferLength = 1024;
unsafe
{
    int* buffer = stackalloc int[bufferLength];
    socket.Send(s, (IntPtr)buffer, bufferLength);
    m = socket.GetLastError();
    var r = 0;
}

Console.ReadLine();