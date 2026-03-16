using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using Shared.WinSock.WSA;
using System.Runtime.InteropServices;

namespace Shared.WinSock.Socket
{
    public class TcpClient : Socket
    {
        #region Fields

        private bool _isConnected;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpClient"/> class.
        /// </summary>
        /// <param name="handle">The reference to the socket.</param>
        public TcpClient(nint handle, bool connected)
        {
            Handle = handle;
            _isConnected = connected;
        }

        #endregion

        #region External Methods

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
        [DllImport("ws2_32.dll")]
        public static extern int recv(nint socket, nint buf, int len, SendDataFlags flags);

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
        [DllImport("ws2_32.dll")]
        public static extern int send(nint socket, nint buff, int len, SendDataFlags flags);

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
        [DllImport("ws2_32.dll")]
        static extern int connect(nint socket, ref SockAddress address, nint length);

        #endregion

        #region Methods

        /// <summary>
        /// Receives data from the websocket connection.
        /// </summary>
        /// <param name="buffer">The buffer to receive data into.</param>
        /// <param name="length">The length of the buffer</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public int Receive(nint buffer, int length)
        {
            return recv(Handle, buffer, length, SendDataFlags.None);
        }

        /// <summary>
        /// Sends data across the socket.
        /// </summary>
        /// <param name="buffer">The buffer data to send.</param>
        /// <param name="length">The length of the buffer</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public int Send(nint buffer, int length)
        {
            return send(Handle, buffer, length, SendDataFlags.None);
        }

        /// <summary>
        /// Connects to a tcp listener.
        /// </summary>
        /// <param name="address">The address to connect to.</param>
        /// <param name="addressSize">The size of the address.</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        public bool Connect(SockAddress address, int addressSize)
        {
            var error = connect(Handle, ref address, addressSize);
            if (error != 0)
            {
                Console.WriteLine("Failed to connect");
                return false;
            }

            _isConnected = true;
            return true;
        }

        /// <summary>
        /// Starts the client procesing activties.
        /// </summary>
        public void StartClientSide()
        {
            unsafe
            {
                int bufferLength = 1024;
                int* buffer = stackalloc int[bufferLength];
                while (_isConnected)
                {

                    Send((IntPtr)buffer, bufferLength);

                    int error = WinSockApi.GetLastError();

                    if (error != 0)
                    {
                        throw new Exception($"Error occured during send with code : {error}");
                    }

                    Console.WriteLine("Sent buffer");
                }
            }
        }

        /// <summary>
        /// Starts the client procesing activties.
        /// </summary>
        public void StartServerSide()
        {
            int bufferLength = 1024; 
            unsafe
            {
                int* buffer = stackalloc int[bufferLength];
                while (_isConnected)
                {
                    Receive((IntPtr)buffer, bufferLength);

                    int error = WinSockApi.GetLastError();
                    if (error != 0)
                    {
                        throw new Exception($"Error occured during recieve with code : {error}");
                    }

                    Console.WriteLine("Received buffer");
                }
            }
        }

        #endregion
    }
}
