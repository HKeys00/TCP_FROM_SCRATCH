using Shared.WinSock;
using System.Runtime.InteropServices;
await Task.Delay(5000);

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
    socket.SendTo(s, (IntPtr)buffer, bufferLength, ref address, Marshal.SizeOf(address));
}