using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;
using WMS.DataLayer.Interfaces;

namespace WMS.DataLayer.Models
{
    public class Shipment : IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; } = RecordState.Active;
        public DateTime CreatedAtUtc { get; set; }
        public string ShippingCode { get; set; }
        public string Customer { get; set; }
        public DateTime DepartureDate { get; set; }
        public ShipmentState ShipmentStatus { get; set; }
    }
}
