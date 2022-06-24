using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Orders.Requests
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public string ClientName { get; set; }
    }
}
