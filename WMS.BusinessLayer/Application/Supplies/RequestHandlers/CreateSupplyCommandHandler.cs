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
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Supplies.RequestHandlers
{
    public class CreateSupplyCommandHandler : IRequestHandler<CreateSupplyCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<CreateSupplyCommandHandler> _logger;

        public CreateSupplyCommandHandler(IMapper mapper, DataContext context, ILogger<CreateSupplyCommandHandler> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handle(CreateSupplyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supply = _mapper.Map<Supply>(request);
                supply.CreatedAtUtc = DateTime.UtcNow;
                supply.Title = $"Y{supply.CreatedAtUtc.Hour}-M{supply.CreatedAtUtc.Month}-D{supply.CreatedAtUtc.Day}-T{supply.CreatedAtUtc.Ticks % 1000}";
                supply.ProductLeft = supply.ProductCount;

                _context.Supplies.Add(supply);
                _context.SaveChanges();

                return supply.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
