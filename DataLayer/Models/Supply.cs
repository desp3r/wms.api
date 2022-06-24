using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;
using WMS.DataLayer.Interfaces;

namespace WMS.DataLayer.Models
{
    public class Supply : IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; } = RecordState.Active;
        public DateTime CreatedAtUtc { get; set; }
        public SupplyState SupplyState { get; set; } = SupplyState.Received;
        public string Title { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public int ProductLeft { get; set; }

    }
}
