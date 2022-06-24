using AutoMapper;
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
    public class GetForTransferCommandHandler : IRequestHandler<GetForTransferCommand, List<Slot>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<GetForTransferCommandHandler> _logger;

        public GetForTransferCommandHandler(IMapper mapper, DataContext context, ILogger<GetForTransferCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }


        public async Task<List<Slot>> Handle(GetForTransferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Slot> result;

                result = _context.Slots.Where(x => (x.ProductId == request.ProductId && x.Id != request.SourceId && x.PlaceLeft > 0) || x.ProductCount == 0).ToList();

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
