using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Users.Commands
{
    public class AuthUserCommand : IRequest<bool>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
