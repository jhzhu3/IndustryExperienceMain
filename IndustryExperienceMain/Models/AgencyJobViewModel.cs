using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IndustryExperienceMain.Models
{
    public class AgencyJobViewModel
    {
        public string AgencyName { get; set; } = null!;

        public string TypeOfWork { get; set; } = null!;

        public string Commitment { get; set; } = null!;

        public string TimeSection { get; set; } = null!;

        public string Workplace { get; set; } = null!;

        public string AgencyLink { get; set; } = null!;

        public string AgencyLogo { get; set; } = null!;
    }
}
