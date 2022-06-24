using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Warehouse.Requests
{
    public class ProductTransferCommand : IRequest<bool>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductCount { get; set; }
    }
}
