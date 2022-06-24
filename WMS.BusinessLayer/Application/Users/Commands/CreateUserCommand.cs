using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.BusinessLayer.Models;

namespace WMS.BusinessLayer.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
