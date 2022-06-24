using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid SupplyId { get; set; }
        public Guid ShipmentId { get; set; }
        public string ProductVendorCode { get; set; }
        public int Amount { get; set; }
    }
}
