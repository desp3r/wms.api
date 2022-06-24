using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Warehouse.Requests;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Warehouse.RequestHandlers
{
    public class GetFreeSlotsQueryHandler : IRequestHandler<GetFreeSlotsQuery, List<Slot>>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetFreeSlotsQueryHandler> _logger;

        public GetFreeSlotsQueryHandler(DataContext context, ILogger<GetFreeSlotsQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Slot>> Handle(GetFreeSlotsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Slots.Where(x => (x.ProductId == request.ProductId && x.PlaceLeft > 0) || x.ProductCount == 0).ToList();

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
