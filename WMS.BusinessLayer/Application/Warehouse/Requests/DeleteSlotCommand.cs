using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Application.Warehouse.Requests
{
    public class DeleteSlotCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
