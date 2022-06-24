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
    public class DeleteSlotCommandHandler : IRequestHandler<DeleteSlotCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<DeleteSlotCommandHandler> _logger;

        public DeleteSlotCommandHandler(IMapper mapper, DataContext context, ILogger<DeleteSlotCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _context.Slots.Where(x => x.Id == request.Id).FirstOrDefault();

                _context.Slots.Remove(item);
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
