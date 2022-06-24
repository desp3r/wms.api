using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Supplies.Requests;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Supplies.RequestHandlers
{
    public class GetSuppliesDetailQueryHandler : IRequestHandler<GetSuppliesDetailQuery, Supply>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetSuppliesDetailQueryHandler> _logger;

        public GetSuppliesDetailQueryHandler(DataContext context, ILogger<GetSuppliesDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Supply> Handle(GetSuppliesDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Supplies.Where(x => x.Id == request.Id).FirstOrDefault();

                return result != null ? result : throw new KeyNotFoundException($"No supply with id: {request.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
