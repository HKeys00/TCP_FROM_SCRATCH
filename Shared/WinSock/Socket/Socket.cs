using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using System.Runtime.InteropServices;
namespace Shared.WinSock.Socket
{
    public class Socket
    {
        [DllImport("ws2_32.dll")]
        public static extern int bind(nint socket, ref SockAddr address, int addressSize);

        [DllImport("ws2_32.dll")]
        public static extern int recv(nint socket, nint buf, int len, SendDataFlags flags);

        [DllImport("ws2_32.dll")]
        public static extern int send(nint socket, nint buff, int len, SendDataFlags flags);

        [DllImport("ws2_32.dll")]
        static extern nint socket(AddressFamilies family, SocketType type, short protocol);

        [DllImport("ws2_32.dll")]
        static extern int connect(nint socket, ref SockAddr address, nint length);

        [DllImport("Ws2_32.dll")]
        static extern nint listen(nint socket, int backlog);

        [DllImport("Ws2_32.dll")]
        static extern nint accept(nint socket, nint address, int addressSize);

        /// <summary>
        /// Binds a socket to a local address and port.
        /// This must be called before Listen() for servers.
        /// </summary>
        /// <param name="socket">Socket handle created by SocketCreate().</param>
        /// <param name="address">The local address structure containing IP and port.</param>
        /// <param name="addressSize">Size of the address structure in bytes.</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure. Use GetLastError() for details.
        /// </returns>
        public int Bind(nint socket, ref SockAddr address, int addressSize)
        {
            return bind(socket, ref address, addressSize);
        }

        /// <summary>
        /// Receives data from a connected socket.
        /// This call blocks until data arrives unless the socket is non-blocking.
        /// </summary>
        /// <param name="socket">The connected socket.</param>
        /// <param name="buffer">Pointer to a buffer that will receive the data.</param>
        /// <param name="length">Maximum number of bytes to receive.</param>
        /// <returns>
        /// Number of bytes received.
        /// Returns 0 if the connection has been closed.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public int Receive(nint socket, nint buffer, int length)
        {
            return recv(socket, buffer, length, SendDataFlags.None);
        }

        /// <summary>
        /// Sends data to a connected socket.
        /// </summary>
        /// <param name="socket">The connected socket.</param>
        /// <param name="buffer">Pointer to the data buffer to send.</param>
        /// <param name="length">Number of bytes to send.</param>
        /// <returns>
        /// Number of bytes successfully sent.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public int Send(nint socket, nint buffer, int length)
        {
            return send(socket, buffer, length, SendDataFlags.None);
        }

        /// <summary>
        /// Marks a bound socket as a listening socket, allowing it to accept incoming connections.
        /// </summary>
        /// <param name="socket">Socket that has already been bound with Bind().</param>
        /// <param name="backlog">Maximum number of pending connections allowed in the queue.</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public nint Listen(nint socket, int backlog)
        {
            return listen(socket, backlog);
        }

        /// <summary>
        /// Accepts an incoming connection from the listening socket.
        /// Creates a new socket for communicating with the connected client.
        /// </summary>
        /// <param name="socket">The listening socket.</param>
        /// <param name="address">Pointer to a buffer that receives the client's address (optional).</param>
        /// <param name="size">Size of the address buffer.</param>
        /// <returns>
        /// Returns a new socket handle for the connected client.
        /// Returns INVALID_SOCKET on failure.
        /// </returns>
        public nint Accept(nint socket, nint address, int size)
        {
            return accept(socket, address, size);
        }

        /// <summary>
        /// Creates a new socket.
        /// </summary>
        /// <param name="family">Address family (e.g., AF_INET for IPv4).</param>
        /// <param name="type">Socket type (e.g., SOCK_STREAM for TCP).</param>
        /// <param name="protocol">Protocol to use (usually 0 for default).</param>
        /// <returns>
        /// Returns a socket handle on success.
        /// Returns INVALID_SOCKET on failure.
        /// </returns>
        public nint SocketCreate(AddressFamilies family, SocketType type, short protocol)
        {
            return socket(family, type, protocol);
        }

        /// <summary>
        /// Establishes a connection to a remote server.
        /// Used by client sockets to connect to a listening server.
        /// </summary>
        /// <param name="socket">The socket created by SocketCreate().</param>
        /// <param name="address">The remote server address and port.</param>
        /// <param name="addressSize">Size of the address structure.</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public int ConnectTo(nint socket, ref SockAddr address, int addressSize)
        {
            return connect(socket, ref address, addressSize);
        }
    }
}