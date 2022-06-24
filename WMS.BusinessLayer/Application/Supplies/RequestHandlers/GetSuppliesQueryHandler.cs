using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Supplies.Requests;
using WMS.BusinessLayer.Models;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Supplies.RequestHandlers
{
    public class GetSuppliesQueryHandler : IRequestHandler<GetSuppliesQuery, List<Supply>>
    {
        private readonly DataContext _context;
        private readonly ILogger<GetSuppliesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSuppliesQueryHandler(DataContext context, ILogger<GetSuppliesQueryHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Supply>> Handle(GetSuppliesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Supplies.ToListAsync();

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
