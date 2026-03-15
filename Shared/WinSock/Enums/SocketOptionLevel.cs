using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.WinSock.Enums
{
    public enum SocketOptionLevel
    {
        IP = 0,
        IPv6 = 0x29,
        Socket = 0xffff,
        Tcp = 6,
        Udp = 0x11
    }
}
