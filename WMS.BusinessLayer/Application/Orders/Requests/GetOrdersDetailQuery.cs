using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Orders.Requests
{
    public class GetOrdersDetailQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
