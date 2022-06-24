using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;
using WMS.DataLayer.Interfaces;

namespace WMS.DataLayer.Models
{
    public class Slot : IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; } = RecordState.Active;
        public DateTime CreatedAtUtc { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public int PlaceLeft { get; set; }
        public int Row { get; set; }
        public int Tier { get; set; }
        public int Box { get; set; }
        public int? ProductId { get; set; }
        public string? ProductTitle { get; set; }
        public int? ProductCount { get; set; } = 0;
    }
}
