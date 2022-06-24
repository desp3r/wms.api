using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.BusinessLayer.Models;

namespace WMS.BusinessLayer.Application.Orders.Requests
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public List<ProductDispatch> ProductDispatches { get; set; }
    }
}
