using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Warehouse.Requests
{
    public class CreateSlotCommand : IRequest<int>
    {
        public int Size { get; set; }
        public int Row { get; set; }
        public int Tier { get; set; }
        public int Box { get; set; }
    }
}
