using Microsoft.AspNetCore.Mvc;
using WMS.DataLayer.Models;

namespace WMS.API.Controllers
{
    [ApiController]
    public abstract class WMSControllerBase : ControllerBase
    {
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
