using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;
using WMS.DataLayer.Interfaces;

namespace WMS.DataLayer.Models
{
    public class Product : IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; } = RecordState.Active;
        public DateTime CreatedAtUtc { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<Supply> Supplies { get; set; } = new ();
    }
}
