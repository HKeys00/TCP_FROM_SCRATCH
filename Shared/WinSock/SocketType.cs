using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.WinSock
{
    public enum SocketType : short
    {
        /// <summary>
        /// stream socket
        /// </summary>
        SOCK_STREAM = 1,

        /// <summary>
        /// datagram socket
        /// </summary>
        SOCK_DGRAM = 2,

        /// <summary>
        /// raw-protocol interface
        /// </summary>
        SOCK_RAW = 3,

        /// <summary>
        /// reliably-delivered message
        /// </summary>
        SOCK_RDM = 4,

        /// <summary>
        /// sequenced packet stream
        /// </summary>
        SOCK_SEQPACKET = 5
    }
}
