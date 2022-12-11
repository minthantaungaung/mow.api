using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Doner
    {
        public int DonerId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? IsMember { get; set; }
        public string? DonatedPrice { get; set; }
        public string? Pwd { get; set; }
    }
}
