using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Orders.Requests;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Orders.RequestHandlers
{
    public class GetOrdersDetailQueryHandler : IRequestHandler<GetOrdersDetailQuery, Order>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetOrdersDetailQueryHandler> _logger;

        public GetOrdersDetailQueryHandler(DataContext context, ILogger<GetOrdersDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> Handle(GetOrdersDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Orders.Where(x => x.Id == request.Id).FirstOrDefault();

                return result != null ? result : throw new KeyNotFoundException($"No order with id: {request.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
