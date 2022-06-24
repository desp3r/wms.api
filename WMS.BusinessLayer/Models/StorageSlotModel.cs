using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Models
{
    public class StorageSlotModel
    {
        public Guid Id { get; set; }
        public string SpecialNumber { get; set; }
        public string Row { get; set; }
        public int Level { get; set; }
        public int Place { get; set; }
        public string? ProductVendorCode { get; set; }
        public string? ProductCount { get; set; }
    }
}
