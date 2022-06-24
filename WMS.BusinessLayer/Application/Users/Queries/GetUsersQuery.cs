using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.BusinessLayer.Models;

namespace WMS.BusinessLayer.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<List<UserModel>>
    {
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SortExpression { get; set; }
    }
}
