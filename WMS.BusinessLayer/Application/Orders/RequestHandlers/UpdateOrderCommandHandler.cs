using AutoMapper;
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
using WMS.DataLayer.Enums;

namespace WMS.BusinessLayer.Application.Orders.RequestHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IMapper mapper, DataContext context, ILogger<UpdateOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _context.Orders.Where(x => x.Id == request.Id).FirstOrDefault();
                order.OrderState = OrderState.Processed;
                _context.Update(order);

                var product = _context.Products.Where(x => x.Id == request.ProductId).FirstOrDefault();
                product.Stock -= request.ProductCount;
                _context.Update(product);

                foreach (var dispatch in request.ProductDispatches)
                {
                    var slot = _context.Slots.Where(x => x.Id == dispatch.SlotId).FirstOrDefault();
                    slot.ProductCount -= dispatch.ProductCount;
                    slot.PlaceLeft += dispatch.ProductCount;

                    if (slot.ProductCount == 0)
                    {
                        slot.ProductId = 0;
                        slot.ProductTitle = string.Empty;
                    }

                    _context.Update(slot);
                }

                _context.SaveChanges();

                return order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
