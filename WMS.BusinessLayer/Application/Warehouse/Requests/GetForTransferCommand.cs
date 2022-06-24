using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Models;

namespace WMS.BusinessLayer.Application.Warehouse.Requests
{
    public class GetForTransferCommand : IRequest<List<Slot>>
    {
        public int ProductId { get; set; }
        public int SourceId { get; set; }
    }
}
