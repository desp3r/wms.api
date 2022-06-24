using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;
using WMS.DataLayer.Interfaces;

namespace WMS.DataLayer.Models
{
    public class Order : IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; } = RecordState.Active;
        public DateTime CreatedAtUtc { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductCount { get; set; }
        public string ClientName { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Waiting;
    }
}
