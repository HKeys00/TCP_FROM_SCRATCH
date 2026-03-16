using System.Runtime.InteropServices;
namespace Shared.WinSock.WSA
{
    /// <summary>
    /// Class that managed the winsock API
    /// </summary>
    public class WinSockApi
    {
        #region External Methods

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto)]
        static extern int WSAGetLastError();

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int WSAStartup(short wVersionRequested, out WSAData wsaData);

        #endregion

        #region Methods

        /// <summary>
        /// Gets the last wsa error to occur.
        /// </summary>
        /// <returns>The int error code.</returns>
        public static int GetLastError()
        {
            return WSAGetLastError();
        }

        /// <summary>
        /// Initiates use of the Winsock DLL by a process.
        /// </summary>
        /// <param name="version">The winsock version number.</param>
        /// <param name="data">A pointer to the WSADATA data structure that is to receive details of the Windows Sockets implementation.</param>
        /// <returns>If successful returns zero otherwise error code.</returns>
        public static int Startup(short version, out WSAData data)
        {
            return WSAStartup(version, out data);
        }

        #endregion
    }
}
