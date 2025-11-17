namespace Shared.WinSock
{
    public enum SendDataFlags
    {
        /// <summary></summary>
        None = 0,

        /// <summary>
        /// Specifies that the data should not be subject to routing.
        /// A windows sockets service provider can choose to ignore this flag.
        /// </summary>
        DontRoute = 1,

        /// <summary>
        /// Sends OOB data (stream-style socket such as SOCK_STREAM only)
        /// </summary>
        OOB = 2,
    }
}
