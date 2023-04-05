using System;
using System.Collections.Generic;

namespace Testing.EFCore.SqlDataLayer.EFCore
{
    public partial class TMemberStatus
    {
        public int FStatusId { get; set; }
        public string FStatus { get; set; } = null!;
        public string? FDescription { get; set; }
    }
}
