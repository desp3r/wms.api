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
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IMapper mapper, DataContext context, ILogger<UpdateProductCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();

                var updatedItem = _mapper.Map(request, item);

                _context.Update(updatedItem);
                await _context.SaveChangesAsync();

                return updatedItem.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
