using Shared.WinSock.Socket;
using System.Collections.Concurrent;

namespace Server
{
    public class ClientHandler
    {
        #region Fields

        private ConcurrentQueue<WorkItem> _inboundQueue;
        private ConcurrentQueue<WorkItem> _outboundQueue;

        #endregion

        #region Properties

        public ConcurrentBag<TcpClient> Clients { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Client Handler class.
        /// </summary>
        public ClientHandler()
        {
            _inboundQueue = new ConcurrentQueue<WorkItem>();
            _outboundQueue = new ConcurrentQueue<WorkItem>();

            Clients = new ConcurrentBag<TcpClient>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the client handler loop
        /// </summary>
        public void Start()
        {
            while (true)
            {

            }
        }

        #endregion
    }
}
