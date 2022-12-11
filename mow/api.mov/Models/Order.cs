using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; } = null!;
        public string? OrderDesc { get; set; }
        public string OrderDatetime { get; set; } = null!;
        public string? VolundeerId { get; set; }
    }
}
