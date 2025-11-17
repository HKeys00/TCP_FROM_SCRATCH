using Shared;
using Shared.WinSock;
using System.Drawing;

Socket socket = new Socket();

var address = new SockAddr(AddressFamilies.AF_INET, 5555, AddressIP4.Loopback);
var errors = socket.WsaStartup(2, out var data);

var addressBuf = new AddressIP4();

var addressNet = socket.Inet(AddressFamilies.AF_INET, "127.0.0.1", ref addressBuf);
var m = socket.GetLastError();
var s = socket.SocketCreate(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
m = socket.GetLastError();
var t = socket.Bind(s, ref address, System.Runtime.InteropServices.Marshal.SizeOf(address));
m = socket.GetLastError();
//socket.Bind(IntPtr.Zero, ref address, 16);

var r = 0;
