using Shared.WinSock.Address;
using Shared.WinSock.Enums;
using System.Runtime.InteropServices;

namespace Shared.WinSock.Socket
{
    public class TcpListener : Socket
    {
        #region Constants

        private int BacklogMaxSize = 50;

        #endregion

        #region Fields

        private SockAddress _address;
        private int _addressSize;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpListener"/> class.
        /// </summary>
        public TcpListener(SockAddress address) 
        {
            _address = address;
            _addressSize = Marshal.SizeOf(address);

            Handle = socket(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);

            int error = 0;
            error = bind(Handle, ref _address, _addressSize);

            if (error != 0)
            {
                throw new Exception($"Error occured during socket binding with code : {error}");
            }

            int enableAddressReuse = 1;
            error = setsockopt(Handle, SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, ref enableAddressReuse, sizeof(int));

            if (error != 0)
            {
                throw new Exception($"Error occured during set socket options with code : {error}");
            }

        }

        #region External Methods

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
        [DllImport("ws2_32.dll")]
        public static extern int bind(nint socket, ref SockAddress address, int addressSize);

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
        [DllImport("ws2_32.dll")]
        static extern nint socket(AddressFamilies family, SocketType type, short protocol);

        /// <summary>
        /// Marks a bound socket as a listening socket, allowing it to accept incoming connections.
        /// </summary>
        /// <param name="socket">Socket that has already been bound with Bind().</param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR on failure.
        /// </returns>
        [DllImport("Ws2_32.dll")]
        static extern nint listen(nint socket, int backlog);

        /// <summary>
        /// Sets a socket option on the specified socket.
        /// This function allows configuration of various socket behaviors such as
        /// address reuse, buffer sizes, timeouts, and keep-alive settings.
        /// </summary>
        /// <param name="s">
        /// Handle to the socket whose option will be modified.
        /// This is the socket returned from socket().
        /// </param>
        /// <param name="level">
        /// The protocol level at which the option is defined. </param>
        /// <param name="optname">
        /// The specific socket option to set. </param>
        /// <param name="optval">
        /// A reference to the value of the option being set.
        /// The interpretation of this value depends on the option.
        /// For many options this is an integer flag (0 = disabled, non-zero = enabled).
        /// </param>
        /// <param name="optlen">
        /// The size of the option value in bytes.
        /// Typically this is sizeof(int).
        /// </param>
        /// <returns>
        /// Returns 0 on success.
        /// Returns SOCKET_ERROR (-1) on failure. Use WSAGetLastError() to retrieve the error code.
        /// </returns>
        [DllImport("Ws2_32.dll")]
        static extern int setsockopt(IntPtr s, SocketOptionLevel level, SocketOptionName optname, ref int optval, int optlen);


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
        [DllImport("Ws2_32.dll")]
        static extern nint accept(nint socket, nint address, int addressSize);

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new unconnected Tcp client.
        /// </summary>
        /// <returns>The new tcp client.</returns>
        public static TcpClient Create()
        {
            var handle = socket(AddressFamilies.AF_INET, SocketType.SOCK_STREAM, 0);
            return new TcpClient(handle, false);
        }

        /// <summary>
        /// Starts listening on the address.
        /// </summary>
        public void Start()
        {
            nint error = listen(Handle, BacklogMaxSize);
            if (error != 0)
            {
                throw new Exception($"Error occured during set socket options with code : {error}");
            }
        }

        /// <summary>
        /// Creates a new TcpClient that accepts a connection.
        /// </summary>
        /// <returns>The new tcp client.</returns>
        public async Task<TcpClient> AcceptAsync()
        {
            nint connected = 0;
            await Task.Run(() =>
            {
                connected = accept(Handle, IntPtr.Zero, 0);
            });
            var client = new TcpClient(connected, true);
            return client;
        }

        #endregion
    }
}
