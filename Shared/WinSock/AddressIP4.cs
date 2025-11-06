using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.WinSock
{
    public struct AddressIP4
    {
        public byte a1;
        public byte a2;
        public byte a3;
        public byte a4;

        public static AddressIP4 Broadcast => new AddressIP4(255, 255, 255, 255);

        public static AddressIP4 AnyAddress => new AddressIP4(0, 0, 0, 0);

        public static AddressIP4 Loopback => new AddressIP4(127, 0, 0, 1);

        public AddressIP4(byte a1,  byte a2, byte a3, byte a4)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.a4 = a4;
        }

    }
}
