using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Orders.Requests;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrdersController : WMSControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IMediator mediator, ILogger<OrdersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetOrdersQuery();
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
                var query = new GetOrdersDetailQuery() { Id = id };
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
        public async Task<IActionResult> Create(CreateOrderCommand command)
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
        public async Task<IActionResult> Update(UpdateOrderCommand command)
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
