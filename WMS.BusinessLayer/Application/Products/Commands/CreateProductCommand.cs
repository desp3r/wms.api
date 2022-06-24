using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
    }
}
