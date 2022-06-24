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

namespace WMS.BusinessLayer.Application.Warehouse.RequestHandlers
{
    public class ProductTransferCommandHandler : IRequestHandler<ProductTransferCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<ProductTransferCommandHandler> _logger;

        public ProductTransferCommandHandler(IMapper mapper, DataContext context, ILogger<ProductTransferCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(ProductTransferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var source = _context.Slots.Where(x => x.Id == request.Source).FirstOrDefault();

                source.ProductCount -= request.ProductCount;
                if (source.ProductCount == 0)
                {
                    source.ProductId = 0;
                    source.ProductTitle = string.Empty;
                }

                source.PlaceLeft += request.ProductCount;

                _context.Update(source);

                var dest = _context.Slots.Where(x => x.Id == request.Destination).FirstOrDefault();

                dest.ProductId = request.ProductId;
                dest.ProductTitle = request.ProductTitle;
                dest.ProductCount += request.ProductCount;
                dest.PlaceLeft -= request.ProductCount;

                _context.Update(dest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
