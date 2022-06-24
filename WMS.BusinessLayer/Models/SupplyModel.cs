using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;

namespace WMS.BusinessLayer.Models
{
    public class SupplyModel
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public SupplyState SupplyState { get; set; } = SupplyState.Received;
        public string Title { get; set; }
        public int ProductId { get; set; }
        public int ProductTitle { get; set; }
        public int ProductCount { get; set; }
    }
}
