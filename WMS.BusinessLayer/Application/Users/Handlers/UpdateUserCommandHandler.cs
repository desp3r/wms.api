using AutoMapper;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IMapper _mapper;
        //private readonly ApplicationContext<User> _context;

        public UpdateUserCommandHandler(IMapper mapper/*, ApplicationContext<User> context*/)
        {
            _mapper = mapper;
            //_context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //var user = _context.Single(request.Id);

            //user = _mapper.Map(request, user);

            //await _context.Update(user);

            return true;
        }
    }
}
