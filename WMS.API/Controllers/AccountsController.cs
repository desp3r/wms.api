using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WMS.BusinessLayer.Application.Accounts;
using WMS.BusinessLayer.Services;
using WMS.DataLayer.Enums;

namespace WMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountsController : WMSControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<AccountResponse>> GetAll()
        {
            var accounts = _accountService.GetAll();
            return Ok(accounts);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<AccountResponse> GetById(int id)
        {
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _accountService.GetById(id);
            return Ok(account);
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<AccountResponse> Create(CreateRequest model)
        {
            var account = _accountService.Create(model);
            return Ok(account);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<AccountResponse> Update(UpdateRequest model)
        {
            if (model.Id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            if (Account.Role != Role.Admin)
                model.Role = null;

            var account = _accountService.Update(model);
            return Ok(account);
        }

        [Authorize]
        [HttpPost("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _accountService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
