using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Supplies.Requests
{
    public class GetSuppliesDetailQuery : IRequest<Supply>
    {
        public int Id { get; set; }
    }
}
