using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Supplies.Requests;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class SuppliesController : WMSControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SuppliesController> _logger;

        public SuppliesController(IMediator mediator, ILogger<SuppliesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetSuppliesQuery();
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
                var query = new GetSuppliesDetailQuery() { Id = id };
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
        public async Task<IActionResult> Create(CreateSupplyCommand command)
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
        public async Task<IActionResult> Update(UpdateSupplyCommand command)
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



        //[HttpPost("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var command = new DeleteProductCommand() { Id = id };
        //        var result = await _mediator.Send(command);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
