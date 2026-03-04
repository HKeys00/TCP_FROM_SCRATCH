using Shared;
using Shared.WinSock;
using System.Drawing;
using System.Runtime.InteropServices;

Socket socket = new Socket();

var address = new SockAddr(AddressFamilies.AF_INET, 5555, AddressIP4.Loopback);

var errors = socket.WsaStartup(2, out var data);
Console.WriteLine((short)address.Family);
Console.WriteLine((short)AddressFamilies.AF_INET);

var addressBuf = new AddressIP4();
var addressNet = socket.Inet(AddressFamilies.AF_INET, "127.0.0.1", ref addressBuf);
var m = socket.GetLastError();
var s = socket.SocketCreate(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
m = socket.GetLastError();
var t = socket.Bind(s, ref address, System.Runtime.InteropServices.Marshal.SizeOf(address));
m = socket.GetLastError();
var l = socket.Listen(s, 1);
m = socket.GetLastError();


var r = 0;
