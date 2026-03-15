namespace Shared.WinSock.Socket
{
    public class Socket
    {
        /// <summary>
        /// The unique iteger identifier representing a network communication endpoint in Windows.
        /// </summary>
        public nint Handle { get; protected set; }
    }
}