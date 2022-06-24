using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.BusinessLayer.Models;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Supplies.Requests
{
    public class GetSuppliesQuery : IRequest<List<Supply>>
    {
    }
}
