using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Products.Queries;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Products.Handlers
{
    public class GetProductsDetailQueryHandler : IRequestHandler<GetProductsDetailQuery, Product>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetProductsDetailQueryHandler> _logger;

        public GetProductsDetailQueryHandler(DataContext context, ILogger<GetProductsDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public async Task<Product> Handle(GetProductsDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();

                return result != null ? result : throw new KeyNotFoundException($"No product with id: {request.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
