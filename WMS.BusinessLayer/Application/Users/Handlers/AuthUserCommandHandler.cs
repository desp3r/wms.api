using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Users.Commands;

namespace WMS.BusinessLayer.Application.Users.Handlers
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, bool>
    {
        public Task<bool> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
