using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Users.Commands;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        //private readonly ApplicationContext<User> _context;
        
        public DeleteUserCommandHandler(/*ApplicationContext<User> context*/)
        {
            //_context = context;
        }
        
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //await _context.Remove(request.Id);

            return Unit.Value;
        }
    }
}
