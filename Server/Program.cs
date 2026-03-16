using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using Shared.WinSock.Socket;
using Shared.WinSock.WSA;
using System.Runtime.InteropServices;

int error = WinSockApi.Startup(2, out var data);
if (error != 0)
{
    throw new Exception($"Error occured during WSA Startup with code : {error}");
}

TcpListener listener = new TcpListener(new SockAddress(AddressFamilies.AF_INET, 5555, AddressIPv4.Loopback));
listener.Start();

while (true)
{
    var client = await listener.AcceptAsync();
    await Task.Run(() =>
    {
        client.StartServerSide();
    });
}
