using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Warehouse.Requests;
using WMS.DataLayer;

namespace WMS.BusinessLayer.Application.Warehouse.RequestHandlers
{
    public class UpdateSlotCommandHandler : IRequestHandler<UpdateSlotCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<UpdateSlotCommandHandler> _logger;

        public UpdateSlotCommandHandler(IMapper mapper, DataContext context, ILogger<UpdateSlotCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _context.Slots.Where(x => x.Id == request.Id).FirstOrDefault();

                var product = _context.Products.Where(x => x.Id == request.ProductId).FirstOrDefault();
                product.Stock += request.ProductCount;

                if (item.PlaceLeft < request.ProductCount) { throw new ArgumentOutOfRangeException(); }

                item = _mapper.Map(request, item);

                item.PlaceLeft = item.Size - request.ProductCount;
                item.ProductCount = item.Size - item.PlaceLeft;

                _context.SaveChanges();

                return item.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
