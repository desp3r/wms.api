using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Supplies.Requests
{
    public class CreateSupplyCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
