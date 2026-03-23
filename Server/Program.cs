using Server;
using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using Shared.WinSock.Socket;
using Shared.WinSock.WSA;

int error = WinSockApi.Startup(2, out var data);
if (error != 0)
{
    throw new Exception($"Error occured during WSA Startup with code : {error}");
}

TcpListener listener = new TcpListener(new SockAddress(AddressFamilies.AF_INET, 5555, AddressIPv4.Loopback));
listener.Start();

ClientHandler handler = new ClientHandler();

_ = Task.Run(() =>
{
    handler.Start();
});

while (true)
{
    var client = await listener.AcceptAsync();
    handler.Clients.Add(client);
}
