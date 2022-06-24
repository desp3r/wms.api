using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Warehouse.Requests;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class WarehouseController : WMSControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(IMediator mediator, ILogger<WarehouseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetSlotsQuery();
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByProduct(int id)
        {
            try
            {
                var query = new GetSlotsQuery() { ProductId = id };
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFreeByProduct(int id)
        {
            try
            {
                var query = new GetFreeSlotsQuery() { ProductId = id };
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var query = new GetSlotsDetailQuery() { Id = id };
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSlotCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSlotCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteSlotCommand() { Id = id };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId:int}/{sourceId:int}")]
        public async Task<IActionResult> GetForTransfer(int productId, int sourceId)
        {
            try
            {
                var command = new GetForTransferCommand() { ProductId = productId, SourceId = sourceId };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductTransfer (ProductTransferCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
