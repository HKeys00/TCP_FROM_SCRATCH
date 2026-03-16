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

var client = TcpListener.Create();

var address = new SockAddress(AddressFamilies.AF_INET, 5555, AddressIPv4.Loopback);

var connected = false;
int retries = 0;
while (!connected)
{
    connected = client.Connect(address, Marshal.SizeOf(address));
    if (!connected)
    {
        retries++;
        await Task.Delay(retries * 1000);
    }
}

client.StartClientSide();