using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Products.Commands;
using WMS.BusinessLayer.Application.Products.Queries;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProductsController : WMSControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;
        
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetProductsQuery();
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
                var query = new GetProductsDetailQuery() { Id = id };
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
        public async Task<IActionResult> Create(CreateProductCommand command)
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
        public async Task<IActionResult> Update(UpdateProductCommand command)
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
                var command = new DeleteProductCommand() { Id = id };
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
