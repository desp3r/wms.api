using AutoMapper;
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
using WMS.DataLayer.Enums;

namespace WMS.BusinessLayer.Application.Supplies.RequestHandlers
{
    public class UpdateSupplyCommandHandler : IRequestHandler<UpdateSupplyCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<UpdateSupplyCommandHandler> _logger;

        public UpdateSupplyCommandHandler(IMapper mapper, DataContext context, ILogger<UpdateSupplyCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }


        public async Task<int> Handle(UpdateSupplyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _context.Supplies.Where(x => x.Id == request.Id).FirstOrDefault();

                var updatedItem = _mapper.Map(request, item);

                if (updatedItem.ProductLeft == 0)
                {
                    updatedItem.SupplyState = SupplyState.Unpacked;
                }

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
