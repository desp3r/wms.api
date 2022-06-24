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
    public class GetSlotsDetailQueryHandler : IRequestHandler<GetSlotsDetailQuery, Slot>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetSlotsDetailQueryHandler> _logger;

        public GetSlotsDetailQueryHandler(DataContext context, ILogger<GetSlotsDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Slot> Handle(GetSlotsDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Slots.Where(x => x.Id == request.Id).FirstOrDefault();

                return result != null ? result : throw new KeyNotFoundException($"No slot with id: {request.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
