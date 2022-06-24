using MediatR;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Products.Queries
{
    public class GetProductsDetailQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
