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
    public class CreateSlotCommandHandler : IRequestHandler<CreateSlotCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<CreateSlotCommandHandler> _logger;

        public CreateSlotCommandHandler(IMapper mapper, DataContext context, ILogger<CreateSlotCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateSlotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slotExists = _context.Slots.Where(x => x.Row == request.Row && x.Tier == request.Tier && x.Box == request.Box).Any();
                if (slotExists) { throw new ArgumentException(); }
                
                var slot = _mapper.Map<Slot>(request);
                slot.CreatedAtUtc = DateTime.UtcNow;
                slot.Title = $"R{slot.Row}-T{slot.Tier}-B{slot.Box}";
                slot.PlaceLeft = slot.Size;

                _context.Slots.Add(slot);
                _context.SaveChanges();

                return slot.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
