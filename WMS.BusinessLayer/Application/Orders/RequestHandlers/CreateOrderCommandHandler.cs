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
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Orders.RequestHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IMapper mapper, DataContext context, ILogger<CreateOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<Order>(request);
                var product = _context.Products.Where(x => x.Id == request.ProductId).FirstOrDefault();

                order.CreatedAtUtc = DateTime.UtcNow;
                order.ProductTitle = product.Title;

                _context.Orders.Add(order);
                _context.SaveChanges();

                return order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
