using Shared;
using Shared.WinSock;

Socket socket = new Socket();

var address = new SockAddr(AddressFamilies.AF_INET, 0, AddressIP4.AnyAddress);
socket.WsaStartup(2, out var data);

var s = socket.SocketCreate(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
var m = socket.GetLastError();


//socket.Bind(IntPtr.Zero, ref address, 16);

var r = 0;
