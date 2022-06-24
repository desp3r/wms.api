using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetOrdersQueryHandler> _logger;

        public GetOrdersQueryHandler(DataContext context, ILogger<GetOrdersQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Orders.ToListAsync();

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
