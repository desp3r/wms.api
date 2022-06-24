using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.BusinessLayer.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string StoredIn { get; set; }
        public string MayBeStoredIn { get; set; }
    }
}
