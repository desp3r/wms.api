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
    public class GetSlotsQueryHandler : IRequestHandler<GetSlotsQuery, List<Slot>>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetSlotsQueryHandler> _logger;

        public GetSlotsQueryHandler(DataContext context, ILogger<GetSlotsQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Slot>> Handle(GetSlotsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Slot> result;
                
                if (request.ProductId == 0)
                {
                    result = _context.Slots.ToList();
                }
                else
                {
                    result = _context.Slots.Where(x => (x.ProductId == request.ProductId)).ToList();
                }

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
