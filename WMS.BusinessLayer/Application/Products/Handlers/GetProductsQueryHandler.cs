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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetProductsDetailQueryHandler> _logger;

        public GetProductsQueryHandler(DataContext context, ILogger<GetProductsDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Products.ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
