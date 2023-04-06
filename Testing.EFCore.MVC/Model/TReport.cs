using System;
using System.Collections.Generic;

namespace Testing.EFCore.MVC.Model
{
    public partial class TReport
    {
        public int FReportId { get; set; }
        public int FReportedMemberId { get; set; }
        public string? FReportMemberId { get; set; }
        public string? FReportDate { get; set; }
    }
}
