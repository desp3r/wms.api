using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Products.Commands;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IMapper mapper, DataContext context, ILogger<CreateProductCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slotExists = _context.Products.Where(x => x.Title == request.Title).Any();
                if (slotExists) { throw new ArgumentException(); }

                var product = _mapper.Map<Product>(request);
                product.CreatedAtUtc = DateTime.UtcNow;

                _context.Products.Add(product);
                _context.SaveChanges();

                return product.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
