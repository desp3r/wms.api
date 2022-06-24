using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;

namespace WMS.BusinessLayer.Models
{
    public class ShipmentModel
    {
        public Guid Id { get; set; }
        public string ShippingCode { get; set; }
        public string Customer { get; set; }
        public DateTime DepartureDate { get; set; }
        public ShipmentState ShipmentStatus { get; set; }
    }
}
