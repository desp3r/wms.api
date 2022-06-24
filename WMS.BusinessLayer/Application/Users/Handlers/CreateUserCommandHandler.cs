using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMS.BusinessLayer.Application.Users.Commands;
using WMS.BusinessLayer.Models;
using WMS.DataLayer;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        //private readonly ApplicationContext<User> _context;

        public CreateUserCommandHandler(IMapper mapper /*ApplicationContext<User> context*/)
        {
            _mapper = mapper;
            //_context = context;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            //var userId = await _context.Add(user);

            return Guid.NewGuid();
        }
    }
}
