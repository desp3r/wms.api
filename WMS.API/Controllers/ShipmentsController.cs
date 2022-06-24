using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ShipmentsController : WMSControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
