using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Products.Commands;
using WMS.DataLayer;

namespace WMS.BusinessLayer.Application.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IMapper mapper, DataContext context, ILogger<DeleteProductCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();

                _context.Products.Remove(item);
                _context.SaveChanges();

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
