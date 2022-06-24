using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.DataLayer.Enums
{
    public enum ShipmentState
    {
        Waiting = 0,
        Packed = 1,
        Shipping = 2,
        Delievered = 3,
        Returned = 4
    }
}
