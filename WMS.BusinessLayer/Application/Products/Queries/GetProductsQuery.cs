using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.BusinessLayer.Models;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
        public string VendorCode { get; set; }
        public string Name { get; set; }
    }
}
