using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.DataLayer.Enums;

namespace WMS.DataLayer.Interfaces
{
    public interface IRecordState
    {
        public int Id { get; set; }
        public RecordState RecordState { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
