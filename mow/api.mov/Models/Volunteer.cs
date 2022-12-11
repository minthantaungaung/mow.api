using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CurrentStatus { get; set; }
    }
}
