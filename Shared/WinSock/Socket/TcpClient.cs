using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using System.Runtime.InteropServices;

namespace Shared.WinSock.Socket
{
    internal class TcpClient : Socket
    {
        [DllImport("ws2_32.dll")]
        public static extern int recv(nint socket, nint buf, int len, SendDataFlags flags);

        [DllImport("ws2_32.dll")]
        public static extern int send(nint socket, nint buff, int len, SendDataFlags flags);

        [DllImport("ws2_32.dll")]
        static extern int connect(nint socket, ref SockAddress address, nint length);

        [DllImport("Ws2_32.dll")]
        static extern nint accept(nint socket, nint address, int addressSize);

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
        public int Connect(nint socket, ref SockAddress address, int addressSize)
        {
            return connect(socket, ref address, addressSize);
        }
    }
}
